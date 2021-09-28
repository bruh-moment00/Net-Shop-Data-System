using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Back_Office_Web_Application.Models;

#nullable disable

namespace Back_Office_Web_Application.Context
{
    public partial class NetStoreDBContext : DbContext
    {
        public NetStoreDBContext()
        {
        }

        public NetStoreDBContext(DbContextOptions<NetStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientsLogin> ClientsLogins { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeesLogin> EmployeesLogins { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }
        public virtual DbSet<OrdersStatus> OrdersStatuses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockStatus> StockStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:NetStoreDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Brand1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Brand")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsFixedLength(true);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Client>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_ClientsLogin1");
            });

            modelBuilder.Entity<ClientsLogin>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("ClientsLogin");

                entity.HasIndex(e => e.Email, "IX_ClientsLogin")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_EmployeesLogin");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Roles");
            });

            modelBuilder.Entity<EmployeesLogin>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("EmployeesLogin");

                entity.HasIndex(e => e.Email, "IX_EmployeesLogin")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.HashPassword)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Clients");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_OrdersStatuses");
            });

            modelBuilder.Entity<OrderedProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedProducts_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedProducts_Products");
            });

            modelBuilder.Entity<OrdersStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Brands");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("Stock");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReceiptDate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(getdate())")
                    .IsFixedLength(true);

                entity.Property(e => e.SellDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Stock_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Products");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_StockStatuses");
            });

            modelBuilder.Entity<StockStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
