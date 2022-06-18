using System;
using System.Collections.Generic;

#nullable disable

namespace Naves_API.Core.Entities
{
    public partial class Stock
    {
        public int IdStock { get; set; }
        public int? TipoNave { get; set; }
        public int StockNave { get; set; }
        public int IdNave { get; set; }
        public DateTime? FechaOcupación { get; set; }

        public virtual Nave IdNaveNavigation { get; set; }
        public virtual TipoNave TipoNaveNavigation { get; set; }
    }
}
