using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miweb.Domain.Dto
{
    public class Cliente_DireccionDto
    {
        public int CDid { get; set; }
        public int? CliId { get; set; }
        public int? DirId { get; set; }
        public bool? Activo { get; set; }
    }
}
