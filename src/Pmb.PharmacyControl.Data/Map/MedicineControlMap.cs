/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Pmb.PharmacyControl.Data.Extensions;

using MedicineControlEntity = Pmb.PharmacyControl.Domain.Entities.MedicineControl;

namespace Pmb.PharmacyControl.Data.Map
{
    public class MedicineControlMap : IEntityTypeConfiguration<MedicineControlEntity>
    {
        private const string TABLE_NAME = "medicine_control";
        public void Configure(EntityTypeBuilder<MedicineControlEntity> builder)
        {
            builder.ToTable(TABLE_NAME);
            builder.MapId(x => x.Id);
            builder.MapInt(x => x.Quantity  , "quantity");
            builder.MapVarchar(x => x.PrescriptionUrl  , "prescription_url", true);

            builder.HasOne(x => x.Medicine);
            builder.HasOne(x => x.Pharmaceutical);

            builder.HasIndex(x => x.PrescriptionUrl )
                .IsUnique(true);
        }        
    }
}
