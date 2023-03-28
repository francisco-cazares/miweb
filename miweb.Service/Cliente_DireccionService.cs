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
    public class Cliente_DireccionService : ICliente_DireccionService
    {
        public List<Cliente_DireccionViewModel> GetListCliente_Direccion()
        {
            using (var context = new ecommerceEntities1())
            {
                List<Cliente_DireccionViewModel> lista = (from _CD in context.Cliente_Direccion
                                                          where _CD.Activo == true
                                                          select new Cliente_DireccionViewModel
                                                          {
                                                              CDid = _CD.CDid,
                                                              CliId = _CD.CliId,
                                                              DirId = _CD.DirId,
                                                              Activo = _CD.Activo
                                                          }).ToList();
                return lista;
            }
        }
        public Cliente_Direccion Create (Cliente_DireccionDto cliente_direccionDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Cliente_Direccion cliente_direccion = context.Cliente_Direccion.FirstOrDefault
                    (cd => cd.CliId == cliente_direccionDto.CliId);
                {
                    if (cliente_direccion?.Activo == true)
                    {
                        throw new Exception($"Cliente ya registrado a una direccion");
                    }
                    else if (cliente_direccionDto?.Activo == false)
                    {
                        context.Entry(cliente_direccionDto).State = EntityState.Modified;
                        context.SaveChanges();
                        return cliente_direccion;

                    }
                    else
                    {
                        var newcliente_direccion = new Cliente_Direccion();
                        {
                            newcliente_direccion.CliId = cliente_direccionDto.CliId;
                            newcliente_direccion.DirId = cliente_direccionDto.DirId;
                            newcliente_direccion.Activo = true;
                        };
                        context.Cliente_Direccion.Add(newcliente_direccion);
                        context.SaveChanges();
                        return newcliente_direccion;
                    }
                }
            }
        }
        public void Update (Cliente_DireccionDto cliente_direccionDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Cliente_Direccion actualizar = context.Cliente_Direccion.FirstOrDefault
                    (CD => CD.CDid == cliente_direccionDto.CDid && CD.CliId == cliente_direccionDto.CliId);
                {
                    if (actualizar == null)
                    {
                        throw new Exception($"Cliente y Direccion no se encuentran registradas");
                    }
                    else
                    {
                        actualizar.CDid = cliente_direccionDto.CDid;
                        actualizar.CliId = cliente_direccionDto.CliId;
                        actualizar.DirId = cliente_direccionDto.DirId;
                       
                        actualizar.Activo = true;


                        context.Entry(actualizar).State = EntityState.Modified;
                        context.SaveChanges();

                    }


                }
            }
        }
    }
    public interface ICliente_DireccionService
    {
        List<Cliente_DireccionViewModel> GetListCliente_Direccion();

        Cliente_Direccion Create(Cliente_DireccionDto cliente_direccionDto);
        void Update(Cliente_DireccionDto cliente_direccionDto);
    }
}
