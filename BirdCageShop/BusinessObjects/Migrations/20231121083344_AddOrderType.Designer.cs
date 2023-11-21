﻿// <auto-generated />
using System;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObjects.Migrations
{
    [DbContext(typeof(CageShopUni_alaContext))]
    [Migration("20231121083344_AddOrderType")]
    partial class AddOrderType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BusinessObjects.Models.Accessory", b =>
                {
                    b.Property<int>("AccessoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccessoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccessoryId"), 1L, 1);

                    b.Property<string>("AccessoryDescription")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AccessoryImg")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AccessoryIMG");

                    b.Property<string>("AccessoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("AccessoryPrice")
                        .HasColumnType("float");

                    b.Property<int?>("AccessoryQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("AccessoryStatus")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int")
                        .HasColumnName("DiscountID");

                    b.HasKey("AccessoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DiscountId");

                    b.ToTable("Accessory", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DiscountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"), 1L, 1);

                    b.Property<decimal?>("Discount1")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("Discount");

                    b.Property<DateTime?>("DiscountFinish")
                        .HasColumnType("date");

                    b.Property<string>("DiscountName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DiscountStart")
                        .HasColumnType("date");

                    b.Property<string>("DiscountStatus")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("DiscountId");

                    b.ToTable("Discount", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FeedbackID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"), 1L, 1);

                    b.Property<string>("FeedBackContent")
                        .HasColumnType("text");

                    b.Property<string>("FeedBackName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<int?>("RatingId")
                        .HasColumnType("int")
                        .HasColumnName("RatingID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("FeedbackId");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("OrderAdress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<string>("OrderEst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrderPhone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal?>("OrderPrice")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("OrderStatus")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("OrderType")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int")
                        .HasColumnName("PaymentID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("OrderId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BusinessObjects.Models.OrderDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailId"), 1L, 1);

                    b.Property<int?>("AccessoryId")
                        .HasColumnType("int")
                        .HasColumnName("AccessoryID");

                    b.Property<int?>("CageId")
                        .HasColumnType("int")
                        .HasColumnName("CageID");

                    b.Property<decimal?>("DetailPrice")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int?>("DetailQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.HasKey("DetailId")
                        .HasName("PK__OrderDet__135C314D642D8210");

                    b.HasIndex("AccessoryId");

                    b.HasIndex("CageId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PaymentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<string>("PaymentName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentId");

                    b.ToTable("PaymentMethod", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Product", b =>
                {
                    b.Property<int>("CageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CageID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CageId"), 1L, 1);

                    b.Property<int?>("Bar")
                        .HasColumnType("int");

                    b.Property<string>("CageImg")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CageIMG");

                    b.Property<string>("CageName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CageStatus")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int")
                        .HasColumnName("DiscountID");

                    b.Property<string>("Material")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CageId")
                        .HasName("PK__Product__792D9FBA31E8206C");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DiscountId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("DoB")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("Status")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UserImg")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserIMG");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserPassword")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BusinessObjects.Models.Accessory", b =>
                {
                    b.HasOne("BusinessObjects.Models.Category", "Category")
                        .WithMany("Accessories")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Accessory_Category");

                    b.HasOne("BusinessObjects.Models.Discount", "Discount")
                        .WithMany("Accessories")
                        .HasForeignKey("DiscountId")
                        .HasConstraintName("FK_Accessory_Discount");

                    b.Navigation("Category");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("BusinessObjects.Models.Feedback", b =>
                {
                    b.HasOne("BusinessObjects.Models.Order", "Order")
                        .WithMany("Feedbacks")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__Feedback__OrderI__33D4B598");

                    b.HasOne("BusinessObjects.Models.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Feedback_Users");

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusinessObjects.Models.Order", b =>
                {
                    b.HasOne("BusinessObjects.Models.PaymentMethod", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK_Orders_PaymentMethod");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("BusinessObjects.Models.OrderDetail", b =>
                {
                    b.HasOne("BusinessObjects.Models.Accessory", "Accessory")
                        .WithMany("OrderDetails")
                        .HasForeignKey("AccessoryId")
                        .HasConstraintName("FK_OrderDetail_Accessory");

                    b.HasOne("BusinessObjects.Models.Product", "Cage")
                        .WithMany("OrderDetails")
                        .HasForeignKey("CageId")
                        .HasConstraintName("FK__OrderDeta__CageI__35BCFE0A");

                    b.HasOne("BusinessObjects.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderDeta__Order__36B12243");

                    b.Navigation("Accessory");

                    b.Navigation("Cage");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BusinessObjects.Models.Product", b =>
                {
                    b.HasOne("BusinessObjects.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Product__Categor__38996AB5");

                    b.HasOne("BusinessObjects.Models.Discount", "Discount")
                        .WithMany("Products")
                        .HasForeignKey("DiscountId")
                        .HasConstraintName("FK__Product__Discoun__398D8EEE");

                    b.Navigation("Category");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("BusinessObjects.Models.User", b =>
                {
                    b.HasOne("BusinessObjects.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__Users__RoleID__3A81B327");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BusinessObjects.Models.Accessory", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BusinessObjects.Models.Category", b =>
                {
                    b.Navigation("Accessories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("BusinessObjects.Models.Discount", b =>
                {
                    b.Navigation("Accessories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("BusinessObjects.Models.Order", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BusinessObjects.Models.PaymentMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BusinessObjects.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BusinessObjects.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BusinessObjects.Models.User", b =>
                {
                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
