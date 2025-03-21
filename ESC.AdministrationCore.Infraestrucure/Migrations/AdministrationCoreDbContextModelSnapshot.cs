﻿// <auto-generated />
using System;
using ESC.AdministrationCore.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ESC.AdministrationCore.Infraestructure.Migrations
{
    [DbContext(typeof(AdministrationCoreDbContext))]
    partial class AdministrationCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ESC.AdministrationCore.Entities.DbSet.Citizen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid?>("IdDocumentType")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdMaritalStatus")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MyDocumentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("image");

                    b.Property<string>("Profession")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDocumentType");

                    b.HasIndex(new[] { "DocumentNumber" }, "DocumentNumber");

                    b.HasIndex(new[] { "LastName" }, "LastName");

                    b.ToTable("Citizens", "dbo");
                });

            modelBuilder.Entity("ESC.AdministrationCore.Entities.DbSet.CitizenMaritalStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CitizenMaritalStatuses", "dbo");
                });

            modelBuilder.Entity("ESC.AdministrationCore.Entities.DbSet.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Countries", "dbo");
                });

            modelBuilder.Entity("ESC.AdministrationCore.Entities.DbSet.DocumentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<short?>("IdDocumentType")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Description");

                    b.ToTable("DocumentTypes", "dbo");
                });

            modelBuilder.Entity("ESC.AdministrationCore.Entities.DbSet.Citizen", b =>
                {
                    b.HasOne("ESC.AdministrationCore.Entities.DbSet.DocumentType", "DocumentType")
                        .WithMany("Citizens")
                        .HasForeignKey("IdDocumentType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("ESC.AdministrationCore.Entities.DbSet.DocumentType", b =>
                {
                    b.Navigation("Citizens");
                });
#pragma warning restore 612, 618
        }
    }
}
