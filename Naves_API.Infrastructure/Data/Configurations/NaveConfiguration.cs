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
    public class NaveConfiguration : IEntityTypeConfiguration<Nave>
    {
        public void Configure(EntityTypeBuilder<Nave> builder)
        {
            builder.HasKey(e => e.IdNave);

            builder.ToTable("tbl_H_Naves");

            builder.Property(e => e.IdNave).HasColumnName("Id_Nave");

            builder.Property(e => e.FechaCreación)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creación");

            builder.Property(e => e.NombreNave)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Nombre_Nave");

            builder.Property(e => e.TipoNave).HasColumnName("Tipo_Nave");

            builder.HasOne(d => d.TipoNaveNavigation)
                .WithMany(p => p.Nave)
                .HasForeignKey(d => d.TipoNave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_H_Naves_tbl_M_Tipo_Nave");
        }
    }
}
