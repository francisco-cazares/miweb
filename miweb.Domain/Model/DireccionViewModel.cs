using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miweb.Domain.Model
{
    public class DireccionViewModel
    {

        public int Dirid { get; set; }
        public string calle { get; set; }
        public int? numero { get; set; }
        public string colonia { get; set; }
        public int? cp { get; set; }
        public int? EstadoId { get; set; }
        public string entre_calles { get; set; }
        public string referencias { get; set; }
        public bool? Activo { get; set; }

    }
}

