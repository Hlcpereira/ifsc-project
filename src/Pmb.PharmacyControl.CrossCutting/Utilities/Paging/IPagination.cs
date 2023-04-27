/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

namespace Pmb.PharmacyControl.CrossCutting.Utilities.Paging
{
    public interface IPagination
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        string SortField { get; set; }
        string SortType { get; set; }
        int MaxPageSize { get; set; }
    }
}