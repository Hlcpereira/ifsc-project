/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Pmb.PharmacyControl.Data.Extensions;

using MedicineEntity = Pmb.PharmacyControl.Domain.Entities.Medicine;

namespace Pmb.PharmacyControl.Data.Map
{
    public class MedicineMap : IEntityTypeConfiguration<MedicineEntity>
    {
        private const string TABLE_NAME = "medicine";
        public void Configure(EntityTypeBuilder<MedicineEntity> builder)
        {
            builder.ToTable(TABLE_NAME);
            builder.MapId(x => x.Id);
            builder.MapEnumAsShort(x => x.ControlLevel, "control_level", true);
            builder.MapVarchar(x => x.Name, "name", false);
        }        
    }
}
