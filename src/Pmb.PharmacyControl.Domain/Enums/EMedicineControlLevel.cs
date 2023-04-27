/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.ComponentModel;

namespace Pmb.PharmacyControl.Domain.Enums
{
    public enum EMedicineControlLevel : short
    {
        [Description("Tarja Vermelha")]
        RedStripe = 1,

        [Description("Tarja Preta")]
        BlackStripe = 2
    }
}