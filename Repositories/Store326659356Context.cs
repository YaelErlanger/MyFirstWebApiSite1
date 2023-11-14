﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace Entities;

public partial class Store326659356Context : DbContext
{
    public Store326659356Context()
    {
    }

    public Store326659356Context(DbContextOptions<Store326659356Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CaegoriesTbl> CaegoriesTbls { get; set; }

    public virtual DbSet<OrderItemTbl> OrderItemTbls { get; set; }

    public virtual DbSet<OrdersTbl> OrdersTbls { get; set; }

    public virtual DbSet<ProductsTbl> ProductsTbls { get; set; }

    public virtual DbSet<UsersTbl> UsersTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LILKT1O;Database=Store_326659356;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CaegoriesTbl>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Caegorie__19093A0B9BBE4E16");

            entity.ToTable("Caegories_tbl");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<OrderItemTbl>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED0681990DD3BD");

            entity.ToTable("OrderItem_tbl");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItemTbls)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_OrderItemTbl_OrderId");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItemTbls)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_OrderItemTbl_ProductId");
        });

        modelBuilder.Entity<OrdersTbl>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders_t__C3905BCF386CAE29");

            entity.ToTable("Orders_tbl");

            entity.Property(e => e.OrderDate).HasColumnType("date");

            entity.HasOne(d => d.User).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_OrdersTbl_OrderId");
        });

        modelBuilder.Entity<ProductsTbl>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDA774E800");

            entity.ToTable("Products_tbl");

            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Image)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.ProductsTbls)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_tbl_Caegories_tbl");
        });

        modelBuilder.Entity<UsersTbl>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users_tb__1788CC4C10880C8F");

            entity.ToTable("Users_tbl");

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
