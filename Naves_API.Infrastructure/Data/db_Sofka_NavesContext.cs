using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Naves_API.Core.Entities;
using Naves_API.Infrastructure.Data.Configurations;

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

        public virtual DbSet<Nave> Nave { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<TipoNave> TipoNaves { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NaveConfiguration());

            modelBuilder.ApplyConfiguration(new StockConfiguration());

            modelBuilder.ApplyConfiguration(new TipoNaveConfiguration());
        }

   
    }
}
