/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

using Pmb.PharmacyControl.Domain.Enums;

namespace Pmb.PharmacyControl.Domain.Entities
{
    public class Medicine
    {
        public Guid Id { get; set; }

        public EMedicineControlLevel ControlLevel { get; set; }

        public string Name { get; set; }
    }
}