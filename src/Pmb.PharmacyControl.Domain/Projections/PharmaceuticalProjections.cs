/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Pmb.PharmacyControl.Domain.Entities;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.Projections
{
    public static class PharmaceuticalProjections
    {
        public static PharmaceuticalVm ToVm(this Pharmaceutical entity)
        {
            var PharmaceuticalVm = new PharmaceuticalVm()
            {
                Id = entity.Id,
                Name = entity.Name,
                RegisterNumber = entity.RegisterNumber,
                HealthUnitId = entity.HealthUnitId
            };

            return PharmaceuticalVm;
        }
    }
}