/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Pmb.PharmacyControl.Domain.Entities;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.Projections
{
    public static class HealthUnitProjections
    {
        public static HealthUnitVm ToVm(this HealthUnit entity)
        {
            var healthUnitVm = new HealthUnitVm()
            {
                Id = entity.Id,
                Name = entity.Name
            };

            return healthUnitVm;
        }
    }
}