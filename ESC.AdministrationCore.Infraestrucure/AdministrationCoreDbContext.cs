﻿using System;
using Microsoft.EntityFrameworkCore;
using ESC.AdminitrationCore.Entities.DbSet;

namespace ESC.AdminitrationCore.Infraestructure
{
    public class AdministrationCoreDbContext : DbContext
    {
        #region Constructor
        public AdministrationCoreDbContext(DbContextOptions<AdministrationCoreDbContext> options) : base(options)
        {
        }
        #endregion

        #region DbSet Instance
        public  DbSet<Citizen> Citizens { get; set; }
        public  DbSet<DocumentType> DocumentTypes { get; set; }
        public  DbSet<CitizenMaritalStatus> CitizenMaritalStatus { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<DocumentType>()
               .HasIndex(m => m.Description);

            modelBuilder.Entity<DocumentType>()
                .HasMany(m => m.Citizens)
                .WithOne(m => m.DocumentType)
                .HasForeignKey(m => m.IdDocumentType)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Citizen>()
              .HasOne(m => m.DocumentType)
              .WithMany(m => m.Citizens)
              .HasForeignKey(m => m.IdDocumentType)
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
