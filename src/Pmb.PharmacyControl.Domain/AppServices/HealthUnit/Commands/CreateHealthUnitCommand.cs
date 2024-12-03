/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Pmb.PharmacyControl.Domain.DataTransferObjects;

namespace Pmb.PharmacyControl.Domain.AppServices.HealthUnit.Commands
{
    public class CreateHealthUnitCommand
    {
        public string Name { get; set; }

        public AddressDTO Address { get; set; }
    }
}