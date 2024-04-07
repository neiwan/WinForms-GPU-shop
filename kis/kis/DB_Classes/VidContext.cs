using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kis.DB_Classes;

public partial class VidContext : DbContext
{
    public VidContext()
    {
    }

    public VidContext(DbContextOptions<VidContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardOrder> CardOrders { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<ShopCard> ShopCards { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=vid;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("Card_pkey");

            entity.ToTable("Card");

            entity.Property(e => e.CardId)
                .ValueGeneratedNever()
                .HasColumnName("card_id");
            entity.Property(e => e.CardGpuName)
                .HasColumnType("character varying[]")
                .HasColumnName("card_gpu_name");
            entity.Property(e => e.CardNum).HasColumnName("card_num");
            entity.Property(e => e.CardPrice).HasColumnName("card_price");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CoolerNum).HasColumnName("cooler_num");
            entity.Property(e => e.Gpu).HasColumnName("gpu");
            entity.Property(e => e.Ram).HasColumnName("ram");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Cards)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("category_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Cards)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("type_id");
        });

        modelBuilder.Entity<CardOrder>(entity =>
        {
            entity.HasKey(e => e.CardOrderId).HasName("Card_order_pkey");

            entity.ToTable("Card_order");

            entity.Property(e => e.CardOrderId)
                .ValueGeneratedNever()
                .HasColumnName("card_order_id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.Card).WithMany(p => p.CardOrders)
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("card_id");

            entity.HasOne(d => d.Order).WithMany(p => p.CardOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("order_id");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("Manufacturer_pkey");

            entity.ToTable("Manufacturer");

            entity.Property(e => e.ManufacturerId)
                .ValueGeneratedNever()
                .HasColumnName("manufacturer_id");
            entity.Property(e => e.ManufacturerName)
                .HasColumnType("character varying[]")
                .HasColumnName("manufacturer_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("Order_pkey");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.ShipmentId).HasColumnName("shipment_id");

            entity.HasOne(d => d.Shipment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipmentId)
                .HasConstraintName("shipment_id");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.ShipmentId).HasName("Shipment_pkey");

            entity.ToTable("Shipment");

            entity.Property(e => e.ShipmentId)
                .ValueGeneratedNever()
                .HasColumnName("shipment_id");
            entity.Property(e => e.ShipmentDate).HasColumnName("shipment_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_id");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.ShopId).HasName("Shop_pkey");

            entity.ToTable("Shop");

            entity.Property(e => e.ShopId)
                .ValueGeneratedNever()
                .HasColumnName("shop_id");
            entity.Property(e => e.ShopCity)
                .HasColumnType("character varying[]")
                .HasColumnName("shop_city");
            entity.Property(e => e.ShopName)
                .HasColumnType("character varying[]")
                .HasColumnName("shop_name");
        });

        modelBuilder.Entity<ShopCard>(entity =>
        {
            entity.HasKey(e => e.CardShopId).HasName("Shop_card_pkey");

            entity.ToTable("Shop_card");

            entity.Property(e => e.CardShopId)
                .ValueGeneratedNever()
                .HasColumnName("card_shop_id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.ShopId).HasColumnName("shop_id");

            entity.HasOne(d => d.Card).WithMany(p => p.ShopCards)
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("Shop_card_card_id_fkey");

            entity.HasOne(d => d.Shop).WithMany(p => p.ShopCards)
                .HasForeignKey(d => d.ShopId)
                .HasConstraintName("shop_id");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("Type_pkey");

            entity.ToTable("Type");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasColumnType("character varying[]")
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("Customer_pkey");

            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.UserAdres)
                .HasColumnType("character varying[]")
                .HasColumnName("user_adres");
            entity.Property(e => e.UserCity)
                .HasColumnType("character varying[]")
                .HasColumnName("user_city");
            entity.Property(e => e.UserLogin)
                .HasColumnType("character varying[]")
                .HasColumnName("user_login");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying[]")
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasColumnType("character varying[]")
                .HasColumnName("user_password");
            entity.Property(e => e.UserRole)
                .HasColumnType("character varying[]")
                .HasColumnName("user_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
