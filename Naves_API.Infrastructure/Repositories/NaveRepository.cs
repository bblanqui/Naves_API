using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Naves_API.Core.Entities;
using Naves_API.Core.Interfaces;
using Naves_API.Infrastructure.Data;

namespace Naves_API.Infrastructure.Repositories
{
    public class NaveRepository: INaveRepository
    {
       private readonly db_Sofka_NavesContext _db_Sofka_Sofka_NavesContext;

        public NaveRepository(db_Sofka_NavesContext context)
        {
            _db_Sofka_Sofka_NavesContext = context;
        }

        

        public async  Task<IEnumerable<Nave>> GetNaves()
        {
            var naves = await _db_Sofka_Sofka_NavesContext.Nave.ToListAsync();
            return naves;
        }
        public async Task<Nave> GetNaves(int id)
        {
            var nave = await _db_Sofka_Sofka_NavesContext.Nave.FirstOrDefaultAsync(nave => nave.IdNave == id);
            return nave;
        }

       

        public async Task InsertNave(Nave nave)
        {
            _db_Sofka_Sofka_NavesContext.Add(nave);
            await _db_Sofka_Sofka_NavesContext.SaveChangesAsync();
        }


        public async  Task<IEnumerable<Nave>> GetNavesLike(string buscar)
        {
            var naves = await _db_Sofka_Sofka_NavesContext.Nave.
                Where(x =>x.NombreNave.Contains(buscar) || x.TipoNaveNavigation.DescripciónNave.Contains(buscar)).
                ToListAsync();
            return naves;
        }
    }
}
