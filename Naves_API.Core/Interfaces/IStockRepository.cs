using Naves_API.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Naves_API.Infrastructure.Core
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStocks();
        Task<Stock> GetStocks(int id);
        Task InsertStock(Stock stock);
        int Stocks(int tipo);
    }
}