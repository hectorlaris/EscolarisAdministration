using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder.
using ESC.AdministrationCore.Entities.DbSet;

namespace ESC.AdministrationCore.Infraestructure;

public class AdministrationCoreDbContext : DbContext
{
    #region Constructor
    public AdministrationCoreDbContext(DbContextOptions<AdministrationCoreDbContext> options) : base(options)
    {
    }
    #endregion

    #region DbSet Instance

    public virtual DbSet<Category> Categories { get; set; }
    public  DbSet<Citizen> Citizens { get; set; }
    public DbSet<CitizenMaritalStatus> CitizenMaritalStatuses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public virtual DbSet<Region> Regions { get; set; }
    public virtual DbSet<Shipper> Shippers { get; set; }
    public virtual DbSet<Territory> Territories { get; set; }
    public DbSet<User> User { get; set; }

    #endregion

    #region Configuration BD

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            SqlConnectionStringBuilder builder = new();

            builder.DataSource = "."; // "ServerName\InstanceName" e.g. @".\sqlexpress"
            builder.InitialCatalog = "db-csi-dev-esc-administration";
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;

            // Because we want to fail faster. Default is 15 seconds.
            builder.ConnectTimeout = 3;

            // If using Windows Integrated authentication.
            //builder.IntegratedSecurity = true;
            builder.IntegratedSecurity = false;

            // If using SQL Server authentication.
            builder.UserID = Environment.GetEnvironmentVariable("SQL_USER");
            builder.Password = Environment.GetEnvironmentVariable("SQL_PASSWORD");

            optionsBuilder.UseSqlServer(builder.ConnectionString);

            optionsBuilder.LogTo(EscolarisDbContextLogger.WriteLine,
                new[] { Microsoft.EntityFrameworkCore
                .Diagnostics.RelationalEventId.CommandExecuting });
        }
    }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

        //base.OnModelCreating(modelBuilder);

        //GUIDs secuenciales por razones de rendimiento
        modelBuilder.Entity<Citizen>()
            .Property(d => d.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        modelBuilder.Entity<Citizen>()
            .HasOne(m => m.DocumentType)
            .WithMany(m => m.Citizens)
            .HasForeignKey(m => m.IdDocumentType)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId).IsFixedLength();

            entity.HasMany(d => d.CustomerTypes).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerCustomerDemo",
                    r => r.HasOne<CustomerDemographic>().WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerCustomerDemo"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerCustomerDemo_Customers"),
                    j =>
                    {
                        j.HasKey("CustomerId", "CustomerTypeId").IsClustered(false);
                        j.ToTable("CustomerCustomerDemo");
                        j.IndexerProperty<string>("CustomerId")
                            .HasMaxLength(5)
                            .IsFixedLength();
                        j.IndexerProperty<string>("CustomerTypeId")
                            .HasMaxLength(10)
                            .IsFixedLength()
                            .HasColumnName("CustomerTypeID");
                    });
        });

        modelBuilder.Entity<CustomerDemographic>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId).IsClustered(false);

            entity.Property(e => e.CustomerTypeId).IsFixedLength();
        });

        modelBuilder.Entity<DocumentType>()
            .Property(d => d.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation).HasConstraintName("FK_Employees_Employees");

            entity.HasMany(d => d.Territories).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeTerritory",
                    r => r.HasOne<Territory>().WithMany()
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Territories"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Employees"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "TerritoryId").IsClustered(false);
                        j.ToTable("EmployeeTerritories");
                        j.IndexerProperty<string>("TerritoryId")
                            .HasMaxLength(20)
                            .HasColumnName("TerritoryID");
                    });
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.CustomerId).IsFixedLength();
            entity.Property(e => e.Freight).HasDefaultValue(0m);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Employees");

            entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Shippers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK_Order_Details");

            entity.Property(e => e.Quantity).HasDefaultValue((short)1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Products");
        });

        modelBuilder.Entity<OrderDetailsExtended>(entity =>
        {
            entity.ToView("Order Details Extended");
        });

        //modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Discontinued).HasDefaultValue(false);
            entity.Property(e => e.ReorderLevel).HasDefaultValue((short)0);
            entity.Property(e => e.UnitPrice).HasDefaultValue(0m);
            entity.Property(e => e.UnitsInStock).HasDefaultValue((short)0);
            entity.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0);

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products).HasConstraintName("FK_Products_Suppliers");
        });

        //GUIDs secuenciales por razones de rendimiento
        modelBuilder.Entity<User>()
            .Property(d => d.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

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

       // OnModelCreatingPartial(modelBuilder);
    }

  //  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

