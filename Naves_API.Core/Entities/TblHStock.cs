using System;
using System.Collections.Generic;

#nullable disable

namespace Naves_API.Core.Data
{
    public partial class TblHStock
    {
        public int IdStock { get; set; }
        public int? TipoNave { get; set; }
        public int StockNave { get; set; }
        public int IdNave { get; set; }
        public DateTime? FechaOcupación { get; set; }

        public virtual TblHNafe IdNaveNavigation { get; set; }
        public virtual TblMTipoNave TipoNaveNavigation { get; set; }
    }
}
