/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

using Pmb.PharmacyControl.Domain.ValueObjects;

namespace Pmb.PharmacyControl.Domain.Entities
{
    public class HealthUnit
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }
    }
}