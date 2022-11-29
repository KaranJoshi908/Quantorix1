using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuantorixProject.Models;

public partial class QuantorixContext : DbContext
{
    public QuantorixContext()
    {
    }

    public QuantorixContext(DbContextOptions<QuantorixContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductInfo> ProductInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbProduc__3213E83FDB6B88D3");

            entity.ToTable("ProductInfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Customer)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("customer");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Product)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
