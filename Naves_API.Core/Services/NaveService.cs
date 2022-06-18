using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naves_API.Core.Entities;
using Naves_API.Core.Interfaces;
using Naves_API.Infrastructure.Core;

namespace Naves_API.Core.Services
{


    public class NaveService : INaveService
    {
        private readonly INaveRepository _naveRepository;// inyeccion de repositorio
        private readonly IStockRepository _stock;// inyeccion de repositorio, stcok
        public NaveService(INaveRepository naveRepository, IStockRepository  stock)
        {

            _naveRepository = naveRepository;
            _stock = stock;
        }

        public async  Task<IEnumerable<Nave>> GetNaves()
        {
            return await _naveRepository.GetNaves();
        }

        public async Task<Nave> GetNaves(int id)
        {
            return await _naveRepository.GetNaves(id);
        }

        public async Task<IEnumerable<Nave>> GetNavesLike(string buscar)
        {
           return  await _naveRepository.GetNavesLike(buscar);
        }

        public async Task InsertNave(Nave nave)
        {

            var stock = _stock.Stocks(nave.TipoNave);

            if (stock > 2)
            {
                throw new Exception("lleno el stock");
            }

            await _naveRepository.InsertNave(nave);
        }
    }
}
