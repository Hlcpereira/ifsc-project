/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.Threading.Tasks;

using PharmaceuticalEntity = Pmb.PharmacyControl.Domain.Entities.Pharmaceutical;
using Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical.Commands;
using Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical.Contracts;
using Pmb.PharmacyControl.Domain.Contracts.Persistance;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.Projections;
using Pmb.PharmacyControl.Domain.ViewModels;
using System;

namespace Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical
{
    public class PharmaceuticalService : BaseService, IPharmaceuticalService
    {
        protected IPharmaceuticalRepository _repository;

        public PharmaceuticalService(
            IUnitOfWork uow,
            IPharmaceuticalRepository repository
        ) : base(uow)
        {
            _repository = repository;
        }

        public async Task<PharmaceuticalVm> Create(CreatePharmaceuticalCommand command)
        {
            var entity = new PharmaceuticalEntity()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                RegisterNumber = command.RegisterNumber,
                HealthUnitId = command.HealthUnitId
            };

            await _repository.AddAsync(entity);
            await CommitAsync();
            
            return entity.ToVm();            
        }

        public async Task<PharmaceuticalVm> Update(UpdatePharmaceuticalCommand command)
        {
            var entity = await _repository.FindAsync(x => x.Id == command.Id);

            entity.Name = command.Name;
            entity.RegisterNumber = command.RegisterNumber;
            entity.HealthUnitId = command.HealthUnitId;

            _repository.Modify(entity);
            await CommitAsync();

            return entity.ToVm();
        }
    }
}