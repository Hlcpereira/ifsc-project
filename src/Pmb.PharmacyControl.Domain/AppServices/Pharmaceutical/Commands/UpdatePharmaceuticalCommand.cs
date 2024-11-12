/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical.Commands
{
    public class UpdatePharmaceuticalCommand : CreatePharmaceuticalCommand
    {
        public Guid Id { get; set; }
    }
}