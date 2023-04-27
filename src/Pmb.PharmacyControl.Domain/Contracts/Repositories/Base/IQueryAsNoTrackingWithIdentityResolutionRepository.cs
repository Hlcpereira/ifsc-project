/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Pmb.PharmacyControl.CrossCutting.Utilities.Paging;

namespace Pmb.PharmacyControl.Domain.Contracts.Repositories.Base
{
    public interface IQueryAsNoTrackingWithIdentityResolutionRepository<T> : IRepositoryBase<T>
        where T : class
    {
        public virtual T FindAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> where, IEnumerable<string> includes = null)
        {
            return CurrentSet(includes: includes).AsNoTrackingWithIdentityResolution().FirstOrDefault(where);
        }

        public virtual Task<T> FindAsNoTrackingWithIdentityResolutionAsync(Expression<Func<T, bool>> where,
            IEnumerable<string> includes = null)
        {
            return CurrentSet(includes: includes).AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(where);
        }

        public virtual T FindAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(includes: includes).AsNoTrackingWithIdentityResolution().FirstOrDefault(where);
        }

        public virtual Task<T> FindAsNoTrackingWithIdentityResolutionAsync(Expression<Func<T, bool>> where,
            params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(includes: includes).AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(where);
        }

        public virtual IQueryable<T> ListAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> where = null,
            int? page = null,
            int? PageSize = null,
            string SortField = null,
            string SortType = null,
            IEnumerable<string> includes = null)
        {
            return CurrentSet(where, page, PageSize, SortField, SortType, includes).AsNoTrackingWithIdentityResolution();
        }

        public virtual IQueryable<T> ListAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> where = null,
            int? page = null,
            int? PageSize = null,
            string SortField = null,
            string SortType = null,
            params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(where, page, PageSize, SortField, SortType, includes).AsNoTrackingWithIdentityResolution();
        }

        public virtual IQueryable<T> ListAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> where, IPagination pagination, IEnumerable<string> includes = null)
        {
            return ListAsNoTrackingWithIdentityResolution(where, pagination.PageIndex, pagination.PageSize, pagination.SortField, pagination.SortType, includes);
        }

        public virtual IQueryable<T> ListAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> where, IPagination pagination, params Expression<Func<T, object>>[] includes)
        {
            return ListAsNoTrackingWithIdentityResolution(where, pagination.PageIndex, pagination.PageSize, pagination.SortField, pagination.SortType, includes);
        }

        public virtual PagedList<T> PagedListAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> where,
            IPagination pagination,
            params Expression<Func<T, object>>[] includes)
        {
            var total = _dataContext.DbContext.Set<T>().Count(where);

            var itens = ListAsNoTrackingWithIdentityResolution(where, pagination, includes);

            return new PagedList<T>(itens, total, pagination.PageSize);
        }
    }
}