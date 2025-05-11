/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Pmb.PharmacyControl.Data.Extensions;

using PharmaceuticalEntity = Pmb.PharmacyControl.Domain.Entities.Pharmaceutical;

namespace Pmb.PharmacyControl.Data.Map
{
    public class PharmaceuticalMap : IEntityTypeConfiguration<PharmaceuticalEntity>
    {
        private const string TABLE_NAME = "pharmaceutical";
        public void Configure(EntityTypeBuilder<PharmaceuticalEntity> builder)
        {
            builder.ToTable(TABLE_NAME);
            builder.MapId(x => x.Id);
            builder.MapVarchar(x => x.Name, "name", false);
            builder.MapVarchar(x => x.RegisterNumber, "register_number", false);
            builder.MapUuid(x => x.HealthUnitId, "health_unit_id");

            builder.HasOne(x => x.HealthUnit);
        }        
    }
}
