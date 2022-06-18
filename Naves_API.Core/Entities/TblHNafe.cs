using System;
using System.Collections.Generic;

#nullable disable

namespace Naves_API.Core.Data
{
    public partial class TblHNafe
    {
        public TblHNafe()
        {
            TblHStocks = new HashSet<TblHStock>();
        }

        public int IdNave { get; set; }
        public string NombreNave { get; set; }
        public int TipoNave { get; set; }
        public DateTime? FechaCreación { get; set; }

        public virtual TblMTipoNave TipoNaveNavigation { get; set; }
        public virtual ICollection<TblHStock> TblHStocks { get; set; }
    }
}
