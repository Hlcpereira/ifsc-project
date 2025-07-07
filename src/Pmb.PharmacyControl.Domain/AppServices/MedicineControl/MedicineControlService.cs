
/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

using MedicineControlEntity = Pmb.PharmacyControl.Domain.Entities.MedicineControl;
using Pmb.PharmacyControl.Domain.Extensions;
using Pmb.PharmacyControl.Domain.AppServices.MedicineControl.Commands;
using Pmb.PharmacyControl.Domain.AppServices.MedicineControl.Contracts;
using Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Commands;
using Pmb.PharmacyControl.Domain.Contracts.Persistance;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.Projections;
using Pmb.PharmacyControl.Domain.ViewModels;
using Pmb.PharmacyControl.Domain.Specs;

namespace Pmb.PharmacyControl.Domain.AppServices.MedicineControl
{
    public class MedicineControlService : BaseService, IMedicineControlService
    {

        protected IMedicineControlRepository _repository;
        protected IMedicineStockRepository _medicineStockRepository;

        public MedicineControlService(
            IUnitOfWork uow,
            IMedicineControlRepository repository,
            IMedicineStockRepository medicineStockRepository
        ) : base(uow)
        {
            _repository = repository;
            _medicineStockRepository = medicineStockRepository;
        }

        public async Task<MedicineControlVm> ControlMedicine(ControlMedicineCommand command)
        {
            var filter = new Filters.MedicineStockFilter()
            {
                HealthUnitId = command.HealthUnitId
            };

            var medicineStockFilterSpec = new MedicineStockSpec()
                .ByFilter(filter)
                .Include(x => x
                    .Include(x => x.Medicine)
                    .Include(x => x.HealthUnit)
                );

            var medicineStock = await _medicineStockRepository.FindAsNoTrackingAsync(medicineStockFilterSpec);

            medicineStock.Quantity -= command.Quantity;

            _medicineStockRepository.Modify(medicineStock);

            var medicineControl = new MedicineControlEntity()
            {
                Id = Guid.NewGuid(),
                PharmaceuticalId = command.PharmaceuticalId,
                MedicineId = command.MedicineId,
                Quantity = command.Quantity,
                PrescriptionUrl = command.PrescriptionUrl
            };

            await _repository.AddAsync(medicineControl);
            await CommitAsync();

            var filterSpec = new MedicineControlSpec()
                .ById(medicineControl.Id)
                .Include(x => x
                    .Include(x => x.Medicine)
                    .Include(x => x.Pharmaceutical)
                );

            medicineControl = await _repository.FindAsNoTrackingAsync(filterSpec);
            
            return medicineControl.ToVm();
        }
    }
}