/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Pmb.PharmacyControl.Domain.Enums;

namespace Pmb.PharmacyControl.Domain.AppServices.Medicine.Commands
{
    public class CreateMedicineCommand
    {
        public EMedicineControlLevel ControlLevel { get; set; }

        public string Name { get; set; }
    }
}