using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miweb.Domain.Dto;
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
        public Producto Create(ProductoDto productoDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Producto producto = context.Producto.FirstOrDefault
                    (pro => pro.sku.ToUpper().Trim() == productoDto.sku.ToUpper().Trim());
                {
                    if (producto?.Activo == true)
                    {
                        throw new Exception($"Producto ya existe");
                    }
                    else if (producto?.Activo == false)
                    {
                        producto.Activo = true;

                        context.Entry(producto).State = EntityState.Modified;
                        context.SaveChanges();
                        return producto;
                    }
                    else
                    {
                        var newproducto = new Producto();
                        {
                            newproducto.nombre = productoDto.nombre;
                            newproducto.marca = productoDto.marca;
                            newproducto.sku = productoDto.sku;
                            newproducto.descripcion = productoDto.descripcion;
                            newproducto.imagen = productoDto.imagen;
                            newproducto.precio = productoDto.precio;
                            newproducto.CatId = productoDto.CatId;
                            newproducto.Activo = true;
                        }

                        context.Producto.Add(newproducto);
                        context.SaveChanges();
                        return newproducto;
                    }
                }
            }
        }
    }
    public interface IProductoService
    {
        List<ProductoViewModel> GetListProducto();
        Producto Create(ProductoDto productoDto);
    }
}
