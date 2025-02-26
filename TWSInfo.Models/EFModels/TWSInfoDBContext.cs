using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TWSInfo.Models.EFModels;

public partial class TWSInfoDBContext : DbContext
{
    public TWSInfoDBContext(DbContextOptions<TWSInfoDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chains> Chains { get; set; }

    public virtual DbSet<StoreTypes> StoreTypes { get; set; }

    public virtual DbSet<Stores> Stores { get; set; }

    public virtual DbSet<SubTypes> SubTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chains>(entity =>
        {
            entity.HasKey(e => e.ChainId).HasName("PK__Chains__AB20BAAA4F19EBFE");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.LogoUrl).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.SubType).WithMany(p => p.Chains)
                .HasForeignKey(d => d.SubTypeId)
                .HasConstraintName("FK_Chains_SubTypes");
        });

        modelBuilder.Entity<StoreTypes>(entity =>
        {
            entity.HasKey(e => e.StoreTypeId).HasName("PK__StoreTyp__49968D78D8A86AD1");

            entity.Property(e => e.IconUrl).HasMaxLength(500);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stores>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Stores__3B82F101D27912C0");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Contact).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsOpen).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Chain).WithMany(p => p.Stores)
                .HasForeignKey(d => d.ChainId)
                .HasConstraintName("FK__Stores__ChainId__398D8EEE");
        });

        modelBuilder.Entity<SubTypes>(entity =>
        {
            entity.HasKey(e => e.SubTypeId).HasName("PK__SubTypes__3108D380B5228F23");

            entity.Property(e => e.IconUrl).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.StoreType).WithMany(p => p.SubTypes)
                .HasForeignKey(d => d.StoreTypeId)
                .HasConstraintName("FK_SubTypes_StoreTypes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
