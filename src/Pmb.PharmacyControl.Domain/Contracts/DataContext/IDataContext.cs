/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;

namespace Pmb.PharmacyControl.Domain.Contracts.DataContext
{
    public interface IDataContext
    {
        DbContext DbContext { get; }
    }
}