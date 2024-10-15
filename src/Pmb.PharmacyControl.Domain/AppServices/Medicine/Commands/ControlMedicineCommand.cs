/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.AppServices.Medicine.Commands
{
    public class ControlMedicineCommand
    {
        public Guid MedicineId { get; set; }
        public Guid PharmaceuticalId { get; set; }
        public string prescriptionUrl { get;}
    }
}