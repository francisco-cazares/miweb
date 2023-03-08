using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miweb.Domain.Dto
{
    public class EstadoDto
    {
        public string Nombre { get; set; }
        public int? PaisID { get; set; }
        public bool? Activo { get; set; }

    }
}
