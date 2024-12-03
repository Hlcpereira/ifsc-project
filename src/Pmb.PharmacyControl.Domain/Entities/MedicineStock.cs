/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.Entities
{
    public class MedicineStock
    {
        public Guid Id { get; set; }

        public Guid HealthUnitId { get; set; }

        public HealthUnit HealthUnit { get; set; }

        public Guid MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        public int Quantity { get; set; }
    }
}