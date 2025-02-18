/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;
using System.Threading.Tasks;

using MedicineStockEntity = Pmb.PharmacyControl.Domain.Entities.MedicineStock;
using Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Commands;
using Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Contracts;
using Pmb.PharmacyControl.Domain.Contracts.Persistance;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.Projections;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.AppServices.MedicineStock
{
    public class MedicineStockService : BaseService, IMedicineStockService
    {

        protected IMedicineStockRepository _repository;

        public MedicineStockService(
            IUnitOfWork uow,
            IMedicineStockRepository repository
        ) : base(uow)
        {
            _repository = repository;
        }

        //public async Task<MedicineStockVm> Create(CreateMedicineStockCommand command)
        public async Task<MedicineStockEntity> Create(CreateMedicineStockCommand command)
        {
            var MedicineStock = new MedicineStockEntity()
            {
                Id = Guid.NewGuid(),
                MedicineId = command.MedicineId,
                HealthUnitId = command.HealthUnitId,
                Quantity = command.Quantity
            };

            await _repository.AddAsync(MedicineStock);
            await CommitAsync();

            return MedicineStock;
        }

        //public async Task<MedicineStockVm> Update(UpdateMedicineStockCommand command)
        public async Task<MedicineStockEntity> Update(UpdateMedicineStockCommand command)
        {
            var entity = await _repository.FindAsync(x => x.Id == command.Id);

            entity.Quantity = command.Quantity;

            _repository.Modify(entity);
            await CommitAsync();

            return entity;
        }
    }
}