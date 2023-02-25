using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miweb.Domain.Model;
using miweb.Persistence.dataBase;

namespace miweb.Service
{
        public class PagoService : IPagoService
        {
        public List<PagoViewModel> GetListPago()
        {
            using (var context = new ecommerceEntities1())
            {
                List<PagoViewModel> lista = (from _pag in context.Pago
                                                 where _pag.Activo == true
                                                 select new PagoViewModel
                                                 {
                                                     PagoId = _pag.PagoId,
                                                     Nombre = _pag.Nombre,
                                                     Imagen = _pag.Imagen,
                                                     Activo = _pag.Activo
                                                 }).ToList();
                return lista;

            }
        }
    }
    public interface IPagoService
    {
        List<PagoViewModel> GetListPago();
    }
}
