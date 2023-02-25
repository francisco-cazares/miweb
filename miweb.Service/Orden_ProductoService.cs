using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miweb.Domain.Model;
using miweb.Persistence.dataBase;

namespace miweb.Service
{
    public class Orden_ProductoService : IOrden_ProductoService
    {
        public List<Orden_ProductoViewModel> GetListOrden_Producto()
        {
            using (var context = new ecommerceEntities1())
            {
                List<Orden_ProductoViewModel> lista = (from _OP in context.Orden_Producto
                                                       where _OP.Activo == true
                                                       select new Orden_ProductoViewModel
                                                       {
                                                           OPid = _OP.OPid,
                                                           OrdId = _OP.OrdId,
                                                           Proid = _OP.Proid,
                                                           cantidad = _OP.cantidad,
                                                           precio = _OP.precio,
                                                           Activo = _OP.Activo
                                                       }).ToList();
                return lista;

            }
        }
    }
    public interface IOrden_ProductoService
    {
        List<Orden_ProductoViewModel> GetListOrden_Producto();
    }
}
