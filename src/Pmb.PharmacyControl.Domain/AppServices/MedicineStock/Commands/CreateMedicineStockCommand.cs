/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Commands
{
    public class CreateMedicineStockCommand
    {
        public Guid MedicineId { get; set; }

        public Guid HealthUnitId { get; set; }

        public int Quantity { get; set; }
    }
}