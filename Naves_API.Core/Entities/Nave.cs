using System;
using System.Collections.Generic;


#nullable disable

namespace Naves_API.Core.Entities
{
    public  class Nave
    {
        public Nave()
        {
            Stock = new HashSet<Stock>();
        }

        public int IdNave { get; set; }
        public string NombreNave { get; set; }
        public int TipoNave { get; set; }
        public DateTime? FechaCreación { get; set; }

        public virtual TipoNave TipoNaveNavigation { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }

       
    }

    
}
