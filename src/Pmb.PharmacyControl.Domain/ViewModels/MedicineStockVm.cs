/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.ViewModels
{
    public class MedicineStockVm
    {
        public Guid Id;

        public MedicineVm Medicine;

        public HealthUnitVm HealthUnit;

        public int Quantity;
    }
}