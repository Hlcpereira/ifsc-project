/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;
using Pmb.PharmacyControl.Domain.Contracts.DataContext;

namespace Pmb.PharmacyControl.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public const string Schema = "public";

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            DbContext = this;
        }

        public DbContext DbContext { get; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.HasDefaultSchema(Schema);
        }
        
        
    }
}