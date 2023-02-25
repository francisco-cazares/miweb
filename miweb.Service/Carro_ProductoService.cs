using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miweb.Domain.Model;
using miweb.Persistence.dataBase;

namespace miweb.Service
{
    public class Carro_ProductoService : ICarro_ProductoService
    {
        public List<Carro_ProductoViewModel> GetListCarro_Producto()
        {
            using (var context = new ecommerceEntities1())
            {
                List<Carro_ProductoViewModel> lista = (from _CarP in context.Carro_Producto
                                                       where _CarP.Activo == true
                                                       select new Carro_ProductoViewModel
                                                       {
                                                           CPid = _CarP.CPid,
                                                           CarroId = _CarP.CarroId,
                                                           Proid = _CarP.Proid,
                                                           cantidad = _CarP.cantidad,
                                                           precio = _CarP.precio,
                                                           Activo = _CarP.Activo
                                                       }).ToList();
                return lista;
            }
        }
    }
    public interface ICarro_ProductoService
    {
        List<Carro_ProductoViewModel> GetListCarro_Producto();
    }
}
