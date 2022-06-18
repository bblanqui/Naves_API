using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naves_API.Core.Entities;

namespace Naves_API.Core.Interfaces
{
    public interface INaveRepository
    {
        Task<IEnumerable<Nave>> GetNaves();
        Task<Nave> GetNaves(int id);

        Task InsertNave(Nave nave);

        Task<IEnumerable<Nave>> GetNavesLike(string buscar);
    }
}
