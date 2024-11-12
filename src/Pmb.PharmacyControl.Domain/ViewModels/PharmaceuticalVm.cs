/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.ViewModels
{
    public class PharmaceuticalVm
    {
        public Guid Id;

        public string Name;

        public string RegisterNumber;

        public Guid HealthUnitId;
    }
}