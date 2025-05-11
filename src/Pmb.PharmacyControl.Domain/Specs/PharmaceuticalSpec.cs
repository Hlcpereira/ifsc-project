/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Linq.Expressions;

using Pmb.PharmacyControl.Domain.Entities;
using Pmb.PharmacyControl.Domain.Filters;

namespace Pmb.PharmacyControl.Domain.Specs
{
    public class PharmaceuticalSpec : Spec<Pharmaceutical>
    {
        public PharmaceuticalSpec ByFilter(PharmaceuticalFilter filter)
        {
            if (filter.Id != Guid.Empty)
                ById(filter.Id);

            return this;
        }
        public PharmaceuticalSpec ById(Guid id)
        {
            AddPredicate(x => x.Id == id);

            return this;
        }

    }
}