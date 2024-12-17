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
    public class MedicineStockSpec : Spec<MedicineStock>
    {
        public MedicineStockSpec ByFilter(MedicineStockFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
                ByMedicineName(filter.Name);

            return this;
        }
        public MedicineStockSpec ByMedicineName(string name)
        {
            AddPredicate(x => x.Medicine.Name == name);

            return this;
        }

    }
}