using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miweb.Domain.Model
{
    public class ProductoViewModel
    {
        public int Proid { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string sku { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public decimal? precio { get; set; }
        public int? CatId { get; set; }
        public bool? Activo { get; set; }


    }
}
