using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miweb.Domain.Model
{
    public class PaisViewModel
    {
        public int paisID { get; set; }
        public string Nombre { get; set; }
        public bool? Activo { get; set; }
    }
}
