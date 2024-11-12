/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Pmb.PharmacyControl.Domain.Contracts.DataContext;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.Entities;

namespace Pmb.PharmacyControl.Data.Repositories
{
    public class PharmaceuticalRepository : Repository<Pharmaceutical>, IPharmaceuticalRepository
    {
        public PharmaceuticalRepository(IDataContext dataContext) : base(dataContext) {}
    }
}