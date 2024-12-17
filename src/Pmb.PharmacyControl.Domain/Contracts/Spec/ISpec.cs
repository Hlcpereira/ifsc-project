/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Pmb.PharmacyControl.Domain.Contracts.Specs
{
    public interface ISpec<T> where T : class
    {
        string ILikePattern(string value);
        Expression<Func<T, bool>> Predicate { get; }
        void AddPredicate(Expression<Func<T, bool>> predicate);
        List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; }
        ISpec<T> Include(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes);
    }
}
