﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pmb.PharmacyControl.Data;

#nullable disable

namespace Pmb.PharmacyControl.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241112190305_PharmaceuticalMigration")]
    partial class PharmaceuticalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pmb.PharmacyControl.Domain.Entities.Medicine", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<short>("ControlLevel")
                        .HasColumnType("smallint")
                        .HasColumnName("control_level");

                    b.Property<string>("Name")
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("medicine", "public");
                });

            modelBuilder.Entity("Pmb.PharmacyControl.Domain.Entities.Pharmaceutical", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("HealthUnitId")
                        .HasColumnType("uuid")
                        .HasColumnName("health_unit_id");

                    b.Property<string>("Name")
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("RegisterNumber")
                        .HasColumnType("varchar")
                        .HasColumnName("register_number");

                    b.HasKey("Id");

                    b.ToTable("pharmaceutical", "public");
                });
#pragma warning restore 612, 618
        }
    }
}