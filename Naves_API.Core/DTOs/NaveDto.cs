using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naves_API.Core.DTOs
{
    public class NaveDto
    {

        public string NombreNave { get; set; }
        public int TipoNave { get; set; }
        public DateTime? FechaCreación { get; set; }
    }
}
