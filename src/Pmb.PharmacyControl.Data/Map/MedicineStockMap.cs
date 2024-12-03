/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Pmb.PharmacyControl.Data.Extensions;

using MedicineStockEntity = Pmb.PharmacyControl.Domain.Entities.MedicineStock;

namespace Pmb.PharmacyControl.Data.Map
{
    public class MedicineStockMap : IEntityTypeConfiguration<MedicineStockEntity>
    {
        private const string TABLE_NAME = "medicine_stock";
        public void Configure(EntityTypeBuilder<MedicineStockEntity> builder)
        {
            builder.ToTable(TABLE_NAME);
            builder.MapId(x => x.Id);
            builder.MapInt(x => x.Quantity  , "quantity");

            builder.HasOne(x => x.Medicine);
            builder.HasOne(x => x.HealthUnit);
        }        
    }
}
