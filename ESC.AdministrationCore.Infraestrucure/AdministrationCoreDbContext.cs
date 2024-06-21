﻿using System;
using Microsoft.EntityFrameworkCore;
using ESC.AdministrationCore.Entities.DbSet;

namespace ESC.AdministrationCore.Infraestructure
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
        public  DbSet<CitizenMaritalStatus> CitizenMaritalStatuses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            //base.OnModelCreating(modelBuilder);

            //GUIDs secuenciales por razones de rendimiento
            modelBuilder.Entity<Citizen>()
                .Property(d => d.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            //GUIDs secuenciales por razones de rendimiento
            modelBuilder.Entity<User>()
                .Property(d => d.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<DocumentType>()
                .Property(d => d.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            // Otras configuraciones
            modelBuilder.Entity<DocumentType>()
               .HasIndex(m => m.Description);

            modelBuilder.Entity<User>()
                .HasIndex(m => m.Username);

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
