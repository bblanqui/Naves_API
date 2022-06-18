using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Naves_API.Core.Entities;
using Naves_API.Core.Interfaces;
using Naves_API.Infrastructure.Core;
using Naves_API.Infrastructure.Data;

namespace Naves_API.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {

        private readonly db_Sofka_NavesContext _db_Sofka_Sofka_NavesContext;

        public StockRepository(db_Sofka_NavesContext context)
        {
            _db_Sofka_Sofka_NavesContext = context;
        }



        public async Task<IEnumerable<Stock>> GetStocks()
        {
            var naves = await _db_Sofka_Sofka_NavesContext.Stock.ToListAsync();
            return naves;
        }

        public async Task<Stock> GetStocks(int id)
        {
            var stock = await _db_Sofka_Sofka_NavesContext.Stock.FirstOrDefaultAsync(stock => stock.IdNave == id);
            return stock;
        }



        public async Task InsertStock(Stock stock)
        {
            _db_Sofka_Sofka_NavesContext.Add(stock);
            await _db_Sofka_Sofka_NavesContext.SaveChangesAsync();
        }

        public int Stocks(int tipo)
        {
            var lista =   _db_Sofka_Sofka_NavesContext.Stock.Where(x => x.TipoNave == tipo).Sum(x => x.StockNave);

            return lista;
        }
    }

}
 