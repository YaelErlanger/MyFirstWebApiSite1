﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(MyStore326659356Context))]
    partial class Store326659356ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.CaegoriesTbl", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.HasKey("CategoryId")
                        .HasName("PK__Caegorie__19093A0B9BBE4E16");

                    b.ToTable("Caegories_tbl", (string)null);
                });

            modelBuilder.Entity("Entities.OrderItemTbl", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("OrderItemId")
                        .HasName("PK__OrderIte__57ED0681990DD3BD");

                    b.HasIndex(new[] { "OrderId" }, "IX_OrderItem_tbl_OrderId");

                    b.HasIndex(new[] { "ProductId" }, "IX_OrderItem_tbl_ProductId");

                    b.ToTable("OrderItem_tbl", (string)null);
                });

            modelBuilder.Entity("Entities.OrdersTbl", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<double>("OrderSum")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId")
                        .HasName("PK__Orders_t__C3905BCF386CAE29");

                    b.HasIndex(new[] { "UserId" }, "IX_Orders_tbl_UserId");

                    b.ToTable("Orders_tbl", (string)null);
                });

            modelBuilder.Entity("Entities.ProductsTbl", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("char(40)")
                        .IsFixedLength();

                    b.Property<string>("Image")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("image");

                    b.Property<int?>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.HasKey("ProductId")
                        .HasName("PK__Products__B40CC6CDA774E800");

                    b.HasIndex(new[] { "CategoryId" }, "IX_Products_tbl_CategoryId");

                    b.ToTable("Products_tbl", (string)null);
                });

            modelBuilder.Entity("Entities.UsersTbl", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("char(30)")
                        .IsFixedLength();

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("char(30)")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("char(30)")
                        .IsFixedLength();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("char(30)")
                        .IsFixedLength();

                    b.HasKey("UserId")
                        .HasName("PK__Users_tb__1788CC4C10880C8F");

                    b.ToTable("Users_tbl", (string)null);
                });

            modelBuilder.Entity("Entities.OrderItemTbl", b =>
                {
                    b.HasOne("Entities.OrdersTbl", "Order")
                        .WithMany("OrderItemTbls")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("fk_OrderItemTbl_OrderId");

                    b.HasOne("Entities.ProductsTbl", "Product")
                        .WithMany("OrderItemTbls")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("fk_OrderItemTbl_ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.OrdersTbl", b =>
                {
                    b.HasOne("Entities.UsersTbl", "User")
                        .WithMany("OrdersTbls")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_OrdersTbl_OrderId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.ProductsTbl", b =>
                {
                    b.HasOne("Entities.CaegoriesTbl", "Category")
                        .WithMany("ProductsTbls")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Products_tbl_Caegories_tbl");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.CaegoriesTbl", b =>
                {
                    b.Navigation("ProductsTbls");
                });

            modelBuilder.Entity("Entities.OrdersTbl", b =>
                {
                    b.Navigation("OrderItemTbls");
                });

            modelBuilder.Entity("Entities.ProductsTbl", b =>
                {
                    b.Navigation("OrderItemTbls");
                });

            modelBuilder.Entity("Entities.UsersTbl", b =>
                {
                    b.Navigation("OrdersTbls");
                });
#pragma warning restore 612, 618
        }
    }
}
