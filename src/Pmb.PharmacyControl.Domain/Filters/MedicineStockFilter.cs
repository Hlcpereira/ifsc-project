/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.Filters
{
    public class MedicineStockFilter
    {
        public string Name { get; set; }
        public Guid HealthUnitId { get; set; }
    }
}