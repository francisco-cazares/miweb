using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miweb.Domain.Dto
{
    public class Orden_ProductoDto
    {
        public int? OrdId { get; set; }
        public int? Proid { get; set; }
        public int? cantidad { get; set; }
        public decimal? precio { get; set; }
        public bool? Activo { get; set; }
    }
}
