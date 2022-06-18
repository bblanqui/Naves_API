using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Naves_API.Core.Entities;

namespace Naves_API.Infrastructure.Data.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(e => e.IdStock);

            builder.ToTable("tbl_H_Stock");

            builder.Property(e => e.IdStock).HasColumnName("Id_Stock");

            builder.Property(e => e.FechaOcupación)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Ocupación");

            builder.Property(e => e.IdNave).HasColumnName("Id_Nave");

            builder.Property(e => e.StockNave).HasColumnName("Stock_Nave");

            builder.Property(e => e.TipoNave).HasColumnName("Tipo_Nave");

            builder.HasOne(d => d.IdNaveNavigation)
                .WithMany(p => p.Stock)
                .HasForeignKey(d => d.IdNave)
                .HasConstraintName("FK_tbl_H_Stock_tbl_H_Naves");

            builder.HasOne(d => d.TipoNaveNavigation)
                .WithMany(p => p.Stock)
                .HasForeignKey(d => d.TipoNave)
                .HasConstraintName("FK_tbl_H_Stock_tbl_M_Tipo_Nave");

        }
    }
}
