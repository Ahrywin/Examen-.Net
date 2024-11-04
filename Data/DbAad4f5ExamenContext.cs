using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Test.Data.ExamenModels;

namespace Test.Data;

public partial class DbAad4f5ExamenContext : DbContext
{
    public DbAad4f5ExamenContext()
    {
    }

    public DbAad4f5ExamenContext(DbContextOptions<DbAad4f5ExamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07B9C5FACC");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Brithday)
                .HasColumnType("datetime")
                .HasColumnName("brithday");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("displayName");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmailVerified).HasColumnName("emailVerified");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("lastLogin");
            entity.Property(e => e.LastName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Name2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name2");
            entity.Property(e => e.Origin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("origin");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.PhoneVerified).HasColumnName("phoneVerified");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photoUrl");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("token");
            entity.Property(e => e.UserRol).HasColumnName("userRol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
