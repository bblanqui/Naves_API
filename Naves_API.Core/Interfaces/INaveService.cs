using System.Collections.Generic;
using Naves_API.Core.Entities;
using System.Threading.Tasks;

namespace Naves_API.Core.Interfaces
{
    public interface INaveService
    {
        Task<IEnumerable<Nave>> GetNaves();
        Task<Nave> GetNaves(int id);

        Task InsertNave(Nave nave);

        Task<IEnumerable<Nave>> GetNavesLike(string buscar);
    }
}