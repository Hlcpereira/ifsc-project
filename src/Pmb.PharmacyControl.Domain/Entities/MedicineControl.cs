/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.Entities
{
    public class MedicineControl
    {
        public Guid Id { get; set; }
        
        public Guid MedicineId { get; set;}

        public Medicine Medicine { get; set; }
        
        public Guid PharmaceuticalId { get; set;}

        public Pharmaceutical Pharmaceutical { get; set; }

        public int Quantity { get; set; }

        public string PrescriptionUrl { get; set; }
    }
}