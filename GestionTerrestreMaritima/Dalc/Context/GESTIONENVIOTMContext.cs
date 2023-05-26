using System;
using System.Collections.Generic;
using GestionTerrestreMaritima.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Unitest.CommonArrage.DB.Data;

namespace GestionTerrestreMaritima.Dalc.Context
{
    public partial class GESTIONENVIOTMContext : DbContext
    {
        public GESTIONENVIOTMContext()
        {
        }

        public GESTIONENVIOTMContext(DbContextOptions<GESTIONENVIOTMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bodega> Bodegas { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Envio> Envios { get; set; } = null!;
        public virtual DbSet<Parametro> Parametros { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ParametroTest> ParametroTest { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.ToTable("BODEGA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Disposicion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISPOSICION");

                entity.Property(e => e.Idfilial)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("IDFILIAL");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Documento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO");
            });

            modelBuilder.Entity<Envio>(entity =>
            {
                entity.ToTable("ENVIO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cantproducto).HasColumnName("CANTPRODUCTO");

                entity.Property(e => e.Descuento).HasColumnName("DESCUENTO");

                entity.Property(e => e.Fechaentrega)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAENTREGA");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAREGISTRO");

                entity.Property(e => e.Filial)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FILIAL");

                entity.Property(e => e.Idbodega).HasColumnName("IDBODEGA");

                entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");

                entity.Property(e => e.Idtipoproducto).HasColumnName("IDTIPOPRODUCTO");

                entity.Property(e => e.Numguia)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NUMGUIA");

                entity.Property(e => e.Numtransporte)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("NUMTRANSPORTE");

                entity.Property(e => e.Precioenvio).HasColumnName("PRECIOENVIO");

                entity.HasOne(d => d.IdbodegaNavigation)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.Idbodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ENVIO__IDBODEGA__52593CB8");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ENVIO__IDCLIENTE__5070F446");

                entity.HasOne(d => d.IdtipoproductoNavigation)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.Idtipoproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ENVIO__IDTIPOPRO__5165187F");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PARAMETRO");

                entity.Property(e => e.Idfilial)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("IDFILIAL");

                entity.Property(e => e.Nombreparametro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREPARAMETRO");

                entity.Property(e => e.Valorparametro)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("VALORPARAMETRO");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
