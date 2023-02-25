using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miweb.Domain.Model
{
    public class OrdenViewModel
    {
        public int Ordid { get; set; }
        public int? ClienteId { get; set; }
        public int? DirId { get; set; }
        public int? PagoId { get; set; }
        public int? EnvId { get; set; } 
        public decimal? total { get; set; }
        public bool? Activo { get; set; }
    }
}
