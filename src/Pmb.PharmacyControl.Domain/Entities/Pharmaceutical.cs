/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.Entities
{
    public class Pharmaceutical
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RegisterNumber { get; set; }
        public Guid HealthUnitId { get; set; }
        public HealthUnit HealthUnit { get; set; }
    }
}