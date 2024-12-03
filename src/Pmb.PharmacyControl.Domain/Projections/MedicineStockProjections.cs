/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Pmb.PharmacyControl.Domain.Entities;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.Projections
{
    public static class MedicineStockProjections
    {
        public static MedicineStockVm ToVm(this MedicineStock entity)
        {
            var medicineStockVm = new MedicineStockVm()
            {
                Id = entity.Id,
                Medicine = entity.Medicine.ToVm(),
                HealthUnit = entity.HealthUnit.ToVm(),
                Quantity = entity.Quantity
            };

            return medicineStockVm;
        }
    }
}