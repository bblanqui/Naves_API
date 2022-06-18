using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Naves_API.Core.Data;
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

        public async  Task<IEnumerable<TblHNafe>> GetNaves()
        {
            var naves = await _db_Sofka_Sofka_NavesContext.TblHNaves.ToListAsync();
            return naves;
        }
    }
}
