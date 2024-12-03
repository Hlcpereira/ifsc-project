/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Commands
{
    public class UpdateMedicineStockCommand : CreateMedicineStockCommand
    {
        public Guid Id { get; set; }
    }
}