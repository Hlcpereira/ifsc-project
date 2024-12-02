/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.Threading.Tasks;
using Pmb.PharmacyControl.Domain.AppServices.HealthUnit.Commands;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.AppServices.HealthUnit.Contracts
{
    public interface IHealthUnitService
    {
        public Task<HealthUnitVm> Get();
        public Task<HealthUnitVm> Create(CreateHealthUnitCommand command);
    }
}