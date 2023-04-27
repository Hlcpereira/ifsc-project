/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Pmb.PharmacyControl.Domain.Contracts.Repositories.Base;

namespace Pmb.PharmacyControl.Domain.Contracts.Repositories
{
    public interface IRepository<T> : 
        ICrudRepository<T>,
        IQueryRepository<T>,
        IQueryAsNoTrackingRepository<T>,
        IQueryAsNoTrackingWithIdentityResolutionRepository<T>
        where T : class
    {
    }
}