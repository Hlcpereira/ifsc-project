/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;
using System.Threading.Tasks;

using MedicineEntity = Pmb.PharmacyControl.Domain.Entities.Medicine;
using Pmb.PharmacyControl.Domain.AppServices.Medicine.Commands;
using Pmb.PharmacyControl.Domain.AppServices.Medicine.Contracts;
using Pmb.PharmacyControl.Domain.Contracts.Persistance;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.Projections;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.AppServices.Medicine
{
    public class MedicineService : BaseService, IMedicineService
    {
        protected IMedicineRepository _repository;

        public MedicineService (
            IUnitOfWork uow,
            IMedicineRepository repository
        ) : base(uow)
        {
            _repository = repository;
        }

        public async Task<MedicineVm> Create(CreateMedicineCommand command)
        {
            var Medicine = new MedicineEntity()
            {
                Id = Guid.NewGuid(),
                ControlLevel = command.ControlLevel,
                Name = command.Name
            };

            await _repository.AddAsync(Medicine);
            await CommitAsync();

            return Medicine.ToVm();
        }
    }
}