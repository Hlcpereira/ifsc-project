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

namespace Pmb.PharmacyControl.Domain.Specs
{
    public class MedicineControlSpec : Spec<MedicineControl>
    {
        public MedicineControlSpec ById(Guid id)
        {
            AddPredicate(x => x.Id == id);

            return this;
        }

    }
}