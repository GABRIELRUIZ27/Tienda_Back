using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TIENDA.Models;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticuloTiendum> ArticuloTienda { get; set; }

    public virtual DbSet<Artículo> Artículos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; }

    public virtual DbSet<Tiendum> Tienda { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticuloTiendum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Articulo_Tienda");

            entity.Property(e => e.ArticuloId).HasColumnName("ArticuloID");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.TiendaId).HasColumnName("TiendaID");

            entity.HasOne(d => d.Articulo).WithMany()
                .HasForeignKey(d => d.ArticuloId)
                .HasConstraintName("FK__Articulo___Artic__2A6B46EF");

            entity.HasOne(d => d.Tienda).WithMany()
                .HasForeignKey(d => d.TiendaId)
                .HasConstraintName("FK__Articulo___Tiend__2B5F6B28");
        });

        modelBuilder.Entity<Artículo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Artículo__D68C8CB10C3990C3");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A7BA6DAC1D");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClienteArticulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("Cliente_Articulo");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.ArticuloId).HasColumnName("ArticuloID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Fecha).HasColumnType("date");

        });

        modelBuilder.Entity<Tiendum>(entity =>
        {
            entity.HasKey(e => e.TiendaId).HasName("PK__Tienda__FC84C42C2A6EF589");

            entity.Property(e => e.TiendaId).HasColumnName("TiendaID");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sucursal)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
