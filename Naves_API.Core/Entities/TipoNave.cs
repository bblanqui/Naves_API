using System;
using System.Collections.Generic;

#nullable disable

namespace Naves_API.Core.Entities
{
    public partial class TipoNave
    {
        public TipoNave()
        {
            Nave = new HashSet<Nave>();
            Stock = new HashSet<Stock>();
        }

        public int IdTipoNave { get; set; }
        public string DescripciónNave { get; set; }

        public virtual ICollection<Nave> Nave { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
