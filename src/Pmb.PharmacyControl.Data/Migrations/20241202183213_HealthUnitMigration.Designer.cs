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
    [Migration("20241202183213_HealthUnitMigration")]
    partial class HealthUnitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pmb.PharmacyControl.Domain.Entities.HealthUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("health_nit", "public");
                });

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

            modelBuilder.Entity("Pmb.PharmacyControl.Domain.Entities.HealthUnit", b =>
                {
                    b.OwnsOne("Pmb.PharmacyControl.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("HealthUnitId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Complement")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("complement");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("neighborhood");

                            b1.Property<string>("Number")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("number");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("zip_code");

                            b1.HasKey("HealthUnitId");

                            b1.ToTable("health_nit", "public");

                            b1.WithOwner()
                                .HasForeignKey("HealthUnitId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
