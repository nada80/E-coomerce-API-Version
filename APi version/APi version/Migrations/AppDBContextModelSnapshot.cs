﻿// <auto-generated />
using System;
using APi_version.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APiversion.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APi_version.Models.AppDBContext+ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateJoined");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Gender");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("APi_version.Models.Brands", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("APi_version.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("APi_version.Models.CartItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartID");

                    b.Property<int>("productId");

                    b.HasKey("ID");

                    b.HasIndex("CartID");

                    b.HasIndex("productId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("APi_version.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("APi_version.Models.Offers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID");

                    b.Property<double>("discount");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("APi_version.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUser_Id");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderStatus");

                    b.Property<double>("TotalPrice");

                    b.HasKey("ID");

                    b.HasIndex("ApplicationUser_Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("APi_version.Models.OrderItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DateOrdered");

                    b.Property<int>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<double>("ProductPrice");

                    b.Property<double>("productDiscount");

                    b.Property<int>("productQuantity");

                    b.Property<double>("productTotalPrice");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("APi_version.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("cardName")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<string>("cardOwnerNAme")
                        .IsRequired();

                    b.Property<string>("userID");

                    b.HasKey("ID");

                    b.HasIndex("userID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("APi_version.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandID");

                    b.Property<int?>("CategoryID");

                    b.Property<string>("Color");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity");

                    b.Property<string>("Size");

                    b.Property<double>("price");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.ToTable("products");
                });

            modelBuilder.Entity("APi_version.Models.Cart", b =>
                {
                    b.HasOne("APi_version.Models.AppDBContext+ApplicationUser", "users")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("APi_version.Models.CartItem", b =>
                {
                    b.HasOne("APi_version.Models.Cart", "cart")
                        .WithMany("cartItems")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("APi_version.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APi_version.Models.Offers", b =>
                {
                    b.HasOne("APi_version.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APi_version.Models.Order", b =>
                {
                    b.HasOne("APi_version.Models.AppDBContext+ApplicationUser", "Users")
                        .WithMany()
                        .HasForeignKey("ApplicationUser_Id");
                });

            modelBuilder.Entity("APi_version.Models.OrderItem", b =>
                {
                    b.HasOne("APi_version.Models.Order", "order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("APi_version.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APi_version.Models.Payment", b =>
                {
                    b.HasOne("APi_version.Models.AppDBContext+ApplicationUser", "Users")
                        .WithMany("payments")
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("APi_version.Models.Product", b =>
                {
                    b.HasOne("APi_version.Models.Brands", "brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("APi_version.Models.Category", "category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");
                });
#pragma warning restore 612, 618
        }
    }
}
