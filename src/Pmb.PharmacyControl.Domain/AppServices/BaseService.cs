/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;
using System.Threading.Tasks;

using Pmb.PharmacyControl.Domain.Contracts.Persistance;
using Pmb.PharmacyControl.Domain.Messages;

namespace Pmb.PharmacyControl.Domain.AppServices
{
    public class BaseService
    {
        private readonly IUnitOfWork _uow;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected async Task<bool> CommitAsync(bool throwIfFails = true)
        {
            if (await _uow.SaveChangesAsync() > 0) return true;

            if (throwIfFails)
                throw new Exception(AppMessages.ProblemSavindDataFriendly);

            return false;
        }
    }
}