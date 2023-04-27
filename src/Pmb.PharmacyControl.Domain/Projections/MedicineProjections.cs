/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Pmb.PharmacyControl.Domain.Entities;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.Projections
{
    public static class MedicineProjections
    {
        public static MedicineVm ToVm(this Medicine entity)
        {
            var medicineVm = new MedicineVm()
            {
                Id = entity.Id,
                ControlLevel = entity.ControlLevel,
                Name = entity.Name
            };

            return medicineVm;
        }
    }
}