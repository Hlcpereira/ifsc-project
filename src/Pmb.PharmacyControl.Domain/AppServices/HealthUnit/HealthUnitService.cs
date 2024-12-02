/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;
using System.Threading.Tasks;

using HealthUnitEntity = Pmb.PharmacyControl.Domain.Entities.HealthUnit;
using Pmb.PharmacyControl.Domain.AppServices.HealthUnit.Commands;
using Pmb.PharmacyControl.Domain.AppServices.HealthUnit.Contracts;
using Pmb.PharmacyControl.Domain.Contracts.Persistance;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.Projections;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.AppServices.HealthUnit
{
    public class HealthUnitService : BaseService, IHealthUnitService
    {
        protected IHealthUnitRepository _repository;

        public HealthUnitService (
            IUnitOfWork uow,
            IHealthUnitRepository repository
        ) : base(uow)
        {
            _repository = repository;
        }

        public async Task<HealthUnitVm> Create(CreateHealthUnitCommand command)
        {
            var HealthUnit = new HealthUnitEntity()
            {
                Id = Guid.NewGuid(),
                Name = command.Name
            };

            await _repository.AddAsync(HealthUnit);
            await CommitAsync();

            return HealthUnit.ToVm();
        }

        public Task<HealthUnitVm> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}