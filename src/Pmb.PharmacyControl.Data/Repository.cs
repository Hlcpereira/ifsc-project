/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;

using Pmb.PharmacyControl.Domain.Contracts.DataContext;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;

namespace Pmb.PharmacyControl.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public IDataContext _dataContext { get; }
        
        public Repository(IDataContext dataContext)
        {
            _dataContext = dataContext;
            _context = dataContext.DbContext;
        }
    }
}
