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
        public Carro_Producto Create (Carro_ProductoDto carro_productoDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Carro_Producto carro_producto = context.Carro_Producto.FirstOrDefault
                    (cp => cp.CarroId == carro_productoDto.CarroId);
                {
                    if (carro_producto?.Activo == true)
                    {
                        throw new Exception($"este carro ya esta registrado");
                    }
                    else if (carro_producto?.Activo == false)
                    {
                        context.Entry(carro_productoDto).State = EntityState.Modified;
                        context.SaveChanges();
                        return carro_producto;
                    }
                    else
                    {
                        var newcarro_producto = new Carro_Producto();
                        {
                            newcarro_producto.CarroId = carro_productoDto.CarroId;
                            newcarro_producto.Proid = carro_productoDto.Proid;
                            newcarro_producto.cantidad = carro_productoDto.cantidad;
                            newcarro_producto.precio = carro_productoDto.precio;
                            newcarro_producto.Activo = true;
                        };
                        context.Carro_Producto.Add(newcarro_producto);
                        context.SaveChanges();
                        return newcarro_producto;
                    }

                }
            }
        }
        public void Update(Carro_ProductoDto carro_productoDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Carro_Producto actualizar = context.Carro_Producto.FirstOrDefault
                    (CP => CP.CarroId == carro_productoDto.CarroId && CP.Proid == carro_productoDto.Proid);
                {
                    if (actualizar == null)
                    {
                        throw new Exception($"Carro o Producto invalido");
                    }
                    else
                    {
                        actualizar.CarroId = carro_productoDto.CarroId;
                        actualizar.Proid = carro_productoDto.Proid;
                        actualizar.cantidad = carro_productoDto.cantidad;
                        actualizar.precio = carro_productoDto.precio;
                        actualizar.Activo = true;


                        context.Entry(actualizar).State = EntityState.Modified;
                        context.SaveChanges();

                    }


                }
            }
        }
    }
    public interface ICarro_ProductoService
    {
        List<Carro_ProductoViewModel> GetListCarro_Producto();

        Carro_Producto Create(Carro_ProductoDto carro_productoDto);
        void Update(Carro_ProductoDto carro_productoDto);
    }
}
