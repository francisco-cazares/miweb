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
        public Orden_Producto Create(Orden_ProductoDto orden_productoDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Orden_Producto orden_producto = context.Orden_Producto.FirstOrDefault(op => op.OrdId == orden_productoDto.OrdId);
                {
                    if (orden_producto?.Activo == true)
                    {
                        throw new Exception($"orden ya relacionada a producto");
                    }
                    else if (orden_producto?.Activo == false)
                    {
                        context.Entry(orden_producto).State = EntityState.Modified;
                        context.SaveChanges();
                        return orden_producto;

                    }
                    else
                    {
                        var neworde_producto = new Orden_Producto();
                        {
                            neworde_producto.OrdId = orden_productoDto.OrdId;
                            neworde_producto.Proid = orden_productoDto.Proid;
                            neworde_producto.cantidad = orden_productoDto.cantidad;
                            neworde_producto.precio = orden_productoDto.precio;
                            neworde_producto.Activo = true;
                        };
                        context.Orden_Producto.Add(neworde_producto);
                        context.SaveChanges();
                        return neworde_producto;
                    }
                }
            }
        }
        public void Update(Orden_ProductoDto orden_productoDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Orden_Producto actualizar = context.Orden_Producto.FirstOrDefault(OP => OP.OrdId == orden_productoDto.OrdId && OP.Proid == orden_productoDto.Proid);
                {
                    if (actualizar == null)
                    {
                        throw new Exception($"Orden o Producto invalidos");
                    }
                    else
                    {
                        actualizar.OrdId = orden_productoDto.OrdId;
                        actualizar.Proid = orden_productoDto.Proid;
                        actualizar.cantidad = orden_productoDto.cantidad;
                        actualizar.precio = orden_productoDto.precio;
                       
                       actualizar.Activo = true;


                        context.Entry(actualizar).State = EntityState.Modified;
                        context.SaveChanges();

                    }
                }
            }
        }
    }
    public interface IOrden_ProductoService
    {
        List<Orden_ProductoViewModel> GetListOrden_Producto();
        Orden_Producto Create(Orden_ProductoDto orden_productoDto);

        void Update(Orden_ProductoDto orden_ProductoDto);
    }
}
