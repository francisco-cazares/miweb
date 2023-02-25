using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miweb.Domain.Model;
using miweb.Persistence.dataBase;


namespace miweb.Service
{
    public class ProductoService : IProductoService
    {
        public List<ProductoViewModel> GetListProducto()
        {
            using (var context = new ecommerceEntities1())
            {
                List<ProductoViewModel> lista = (from _Prod in context.Producto
                                                 where _Prod.Activo == true
                                                 select new ProductoViewModel
                                                 {
                                                     Proid = _Prod.Proid,
                                                     nombre = _Prod.nombre,
                                                     marca = _Prod.marca,
                                                     sku = _Prod.sku,
                                                     descripcion = _Prod.descripcion,
                                                     imagen = _Prod.imagen,
                                                     precio = _Prod.precio,
                                                     CatId = _Prod.CatId,
                                                     Activo = _Prod.Activo
                                                 }).ToList();

                return lista;
            }
        }
    }
    public interface IProductoService
    {
        List<ProductoViewModel> GetListProducto();
    }
}
