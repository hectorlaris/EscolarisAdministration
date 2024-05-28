﻿// <auto-generated />
using System;
using ESC.AdminitrationCore.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ESC.AdministrationCore.Infraestrucure.Migrations
{
    [DbContext(typeof(AdministrationCoreDbContext))]
    [Migration("20240528171712_AddCountryEntity")]
    partial class AddCountryEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ESC.AdminitrationCore.Entities.DbSet.Citizen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.HasIndex("IdMaritalStatus");

                    b.HasIndex(new[] { "DocumentNumber" }, "DocumentNumber");

                    b.HasIndex(new[] { "LastName" }, "LastName");

                    b.ToTable("Citizens", "dbo");
                });

            modelBuilder.Entity("ESC.AdminitrationCore.Entities.DbSet.CitizenMaritalStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CitizenMaritalStatus", "dbo");
                });

            modelBuilder.Entity("ESC.AdminitrationCore.Entities.DbSet.Country", b =>
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

                    b.ToTable("Country", "dbo");
                });

            modelBuilder.Entity("ESC.AdminitrationCore.Entities.DbSet.DocumentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<short?>("DocumentTypeSimmit")
                        .HasColumnType("smallint");

                    b.Property<short?>("IdDocumentType")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Description");

                    b.ToTable("DocumentTypes", "dbo");
                });

            modelBuilder.Entity("ESC.AdminitrationCore.Entities.DbSet.Citizen", b =>
                {
                    b.HasOne("ESC.AdminitrationCore.Entities.DbSet.DocumentType", "DocumentType")
                        .WithMany("Citizens")
                        .HasForeignKey("IdDocumentType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ESC.AdminitrationCore.Entities.DbSet.CitizenMaritalStatus", "CitizenMaritalStatus")
                        .WithMany("Citizens")
                        .HasForeignKey("IdMaritalStatus");

                    b.Navigation("CitizenMaritalStatus");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("ESC.AdminitrationCore.Entities.DbSet.CitizenMaritalStatus", b =>
                {
                    b.Navigation("Citizens");
                });

            modelBuilder.Entity("ESC.AdminitrationCore.Entities.DbSet.DocumentType", b =>
                {
                    b.Navigation("Citizens");
                });
#pragma warning restore 612, 618
        }
    }
}
