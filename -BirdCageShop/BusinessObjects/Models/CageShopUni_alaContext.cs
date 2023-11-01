
﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models
{
    public partial class CageShopUni_alaContext : DbContext
    {
        public CageShopUni_alaContext()
        {
        }

        public CageShopUni_alaContext(DbContextOptions<CageShopUni_alaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accessory> Accessories { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        protected string GetConnectionString()
        {
            //IConfiguration config = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //            .AddJsonFile("appsettings.json", true, true)
            //            .Build();
            //var strConn = config["ConnectionStrings: DefaultConnectionStringDB "];

            //return strConn;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfiguration config = builder.Build();
            return config.GetConnectionString("CageShopUni_alaDB");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessory>(entity =>
            {
                entity.ToTable("Accessory");

                entity.Property(e => e.AccessoryId).HasColumnName("AccessoryID");

                entity.Property(e => e.AccessoryDescription).HasMaxLength(255);

                entity.Property(e => e.AccessoryImg)
                    .HasColumnType("image")
                    .HasColumnName("AccessoryIMG");

                entity.Property(e => e.AccessoryName).HasMaxLength(50);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Accessories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Accessory_Category");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Accessories)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_Accessory_Discount");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.Discount1)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("Discount");

                entity.Property(e => e.DiscountFinish).HasColumnType("date");

                entity.Property(e => e.DiscountName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountStart).HasColumnType("date");

                entity.Property(e => e.DiscountStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.FeedBackContent).HasColumnType("text");

                entity.Property(e => e.FeedBackName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Feedback__OrderI__239E4DCF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Feedback_Users");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.OrderAdress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrderPrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Orders_PaymentMethod");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId)
                    .HasName("PK__OrderDet__135C314D4CF950ED");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.DetailId).HasColumnName("DetailID");

                entity.Property(e => e.AccessoryId).HasColumnName("AccessoryID");

                entity.Property(e => e.CageId).HasColumnName("CageID");

                entity.Property(e => e.DetailPrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Accessory)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.AccessoryId)
                    .HasConstraintName("FK_OrderDetail_Accessory");

                entity.HasOne(d => d.Cage)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CageId)
                    .HasConstraintName("FK__OrderDeta__CageI__25869641");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__267ABA7A");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("PaymentMethod");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PaymentName).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.CageId)
                    .HasName("PK__Product__792D9FBACE0D77BB");

                entity.ToTable("Product");

                entity.Property(e => e.CageId).HasColumnName("CageID");

                entity.Property(e => e.CageImg).HasColumnName("CageIMG");

                entity.Property(e => e.CageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.Material).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__29572725");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK__Product__Discoun__2A4B4B5E");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserImg).HasColumnName("UserIMG");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleID__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
