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

    public virtual DbSet<Favorites> Favorites { get; set; }

    public virtual DbSet<StoreTypes> StoreTypes { get; set; }

    public virtual DbSet<Stores> Stores { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chains>(entity =>
        {
            entity.HasKey(e => e.ChainId).HasName("PK__Chains__AB20BAAA4F19EBFE");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.LogoUrl).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Type).WithMany(p => p.Chains)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chains_StoreTypes");
        });

        modelBuilder.Entity<Favorites>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__Favorite__CE74FAD5DECB2900");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Store).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__Favorites__Store__4316F928");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Favorites__UserI__4222D4EF");
        });

        modelBuilder.Entity<StoreTypes>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__StoreTyp__49968D78D8A86AD1");

            entity.Property(e => e.IconUrl).HasMaxLength(500);
            entity.Property(e => e.Type)
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

            entity.HasOne(d => d.Type).WithMany(p => p.Stores)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stores_StoreTypes");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CEDA1062F");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534E40F5961").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
