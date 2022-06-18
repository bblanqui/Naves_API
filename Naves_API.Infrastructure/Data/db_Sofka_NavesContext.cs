using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Naves_API.Core.Data;

#nullable disable

namespace Naves_API.Infrastructure.Data
{
    public  class db_Sofka_NavesContext : DbContext
    {
        public db_Sofka_NavesContext()
        {
        }

        public db_Sofka_NavesContext(DbContextOptions<db_Sofka_NavesContext> options): base(options)
        {
        }

        public virtual DbSet<TblHNafe> TblHNaves { get; set; }
        public virtual DbSet<TblHStock> TblHStocks { get; set; }
        public virtual DbSet<TblMTipoNave> TblMTipoNaves { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblHNafe>(entity =>
            {
                entity.HasKey(e => e.IdNave);

                entity.ToTable("tbl_H_Naves");

                entity.Property(e => e.IdNave).HasColumnName("Id_Nave");

                entity.Property(e => e.FechaCreación)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creación");

                entity.Property(e => e.NombreNave)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Nave");

                entity.Property(e => e.TipoNave).HasColumnName("Tipo_Nave");

                entity.HasOne(d => d.TipoNaveNavigation)
                    .WithMany(p => p.TblHNaves)
                    .HasForeignKey(d => d.TipoNave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_H_Naves_tbl_M_Tipo_Nave");
            });

            modelBuilder.Entity<TblHStock>(entity =>
            {
                entity.HasKey(e => e.IdStock);

                entity.ToTable("tbl_H_Stock");

                entity.Property(e => e.IdStock).HasColumnName("Id_Stock");

                entity.Property(e => e.FechaOcupación)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Ocupación");

                entity.Property(e => e.IdNave).HasColumnName("Id_Nave");

                entity.Property(e => e.StockNave).HasColumnName("Stock_Nave");

                entity.Property(e => e.TipoNave).HasColumnName("Tipo_Nave");

                entity.HasOne(d => d.IdNaveNavigation)
                    .WithMany(p => p.TblHStocks)
                    .HasForeignKey(d => d.IdNave)
                    .HasConstraintName("FK_tbl_H_Stock_tbl_H_Naves");

                entity.HasOne(d => d.TipoNaveNavigation)
                    .WithMany(p => p.TblHStocks)
                    .HasForeignKey(d => d.TipoNave)
                    .HasConstraintName("FK_tbl_H_Stock_tbl_M_Tipo_Nave");
            });

            modelBuilder.Entity<TblMTipoNave>(entity =>
            {
                entity.HasKey(e => e.IdTipoNave);

                entity.ToTable("tbl_M_Tipo_Nave");

                entity.Property(e => e.IdTipoNave).HasColumnName("Id_Tipo_Nave");

                entity.Property(e => e.DescripciónNave)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Descripción_Nave");
            });

        
        }

   
    }
}
