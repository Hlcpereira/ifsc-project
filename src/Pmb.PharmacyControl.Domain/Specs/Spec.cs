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

using Pmb.PharmacyControl.CrossCutting.Utilities.Linq;
using Pmb.PharmacyControl.Domain.Contracts.Specs;

namespace Pmb.PharmacyControl.Domain.Specs
{
    public class Spec<T> : ISpec<T> where T : class
    {
        public string ILikePattern(string value) => $"%{value}%";
        public Expression<Func<T, bool>> Predicate { get; private set; } = PredicateBuilder.True<T>();
        public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; } = new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();
        
        public void AddPredicate(Expression<Func<T, bool>> predicate)
        {
            Predicate = Predicate.And(predicate);
        }

        public ISpec<T> Include(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes)
        {
            Includes.Add(includes);
            return this;
        }
    }
}