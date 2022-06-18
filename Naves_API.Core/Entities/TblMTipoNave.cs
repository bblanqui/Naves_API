using System;
using System.Collections.Generic;

#nullable disable

namespace Naves_API.Core.Data
{
    public partial class TblMTipoNave
    {
        public TblMTipoNave()
        {
            TblHNaves = new HashSet<TblHNafe>();
            TblHStocks = new HashSet<TblHStock>();
        }

        public int IdTipoNave { get; set; }
        public string DescripciónNave { get; set; }

        public virtual ICollection<TblHNafe> TblHNaves { get; set; }
        public virtual ICollection<TblHStock> TblHStocks { get; set; }
    }
}
