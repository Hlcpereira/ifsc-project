/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Newtonsoft.Json;

namespace Pmb.PharmacyControl.CrossCutting.Utilities.Paging
{
    public class Pagination : IPagination
    {
        public virtual int PageIndex { get; set; } = 1;
        private int _pageSize = 20;

        public virtual int PageSize
        {
            get => _pageSize > MaxPageSize ? MaxPageSize : _pageSize;
            set => _pageSize = value;
        }
        public virtual string SortField { get; set; } = "Id";
        public virtual string SortType { get; set; } = "asc";

        [JsonIgnore]
        public virtual int MaxPageSize { get; set; } = 20;
    }
}

