/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

using Pmb.PharmacyControl.Domain.Enums;

namespace Pmb.PharmacyControl.Domain.ViewModels
{
    public class MedicineVm
    {
        public Guid Id;

        public EMedicineControlLevel ControlLevel;

        public string Name;
    }
}