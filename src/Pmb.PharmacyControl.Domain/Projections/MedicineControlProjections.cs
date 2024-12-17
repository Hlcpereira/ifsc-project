/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Pmb.PharmacyControl.Domain.Entities;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.Projections
{
    public static class MedicineControlProjections
    {
        public static MedicineControlVm ToVm(this MedicineControl entity)
        {
            var medicineControlVm = new MedicineControlVm()
            {
                Id = entity.Id,
                Medicine = entity.Medicine.ToVm(),
                Pharmaceutical = entity.Pharmaceutical.ToVm(),
                Quantity = entity.Quantity,
                PrescriptionUrl = entity.PrescriptionUrl
            };

            return medicineControlVm;
        }
    }
}