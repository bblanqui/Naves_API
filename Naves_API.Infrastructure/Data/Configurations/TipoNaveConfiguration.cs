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
    public class TipoNaveConfiguration : IEntityTypeConfiguration<TipoNave>
    {
        public void Configure(EntityTypeBuilder<TipoNave> builder)
        {

            builder.HasKey(e => e.IdTipoNave);

            builder.ToTable("tbl_M_Tipo_Nave");

            builder.Property(e => e.IdTipoNave).HasColumnName("Id_Tipo_Nave");

            builder.Property(e => e.DescripciónNave)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Descripción_Nave");
        }
    }
}
