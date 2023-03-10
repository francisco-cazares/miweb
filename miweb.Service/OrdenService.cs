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
    public class OrdenService : IOrdenService
    {
        public List<OrdenViewModel> GetListOrden()
        {
            using (var context = new ecommerceEntities1())
            {
                List<OrdenViewModel> lista = (from _Ord in context.Orden
                                              where _Ord.Activo == true
                                              select new OrdenViewModel
                                              {
                                                  Ordid = _Ord.Ordid,
                                                  ClienteId = _Ord.ClienteId,
                                                  DirId = _Ord.DirId,
                                                  PagoId = _Ord.PagoId,
                                                  EnvId = _Ord.EnvId,
                                                  total = _Ord.total,
                                                  Activo = _Ord.Activo
                                              }).ToList();
                return lista;
            }
        }
        public Orden Create(OrdenDto ordenDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Orden orden = context.Orden.FirstOrDefault(o => o.EnvId == ordenDto.EnvId);
                {
                    if (orden?.Activo == true)
                    {
                        throw new Exception($"Orden ya enviada");
                    }
                    else if (orden?.Activo == false)
                    {
                        context.Entry(orden).State = EntityState.Modified;
                        context.SaveChanges();
                        return orden;
                    }
                    else
                    {
                        var neworden = new Orden();
                        {
                            neworden.ClienteId = ordenDto.ClienteId;
                            neworden.DirId = ordenDto.DirId;
                            neworden.PagoId = ordenDto.PagoId;
                            neworden.EnvId = ordenDto.EnvId;
                            neworden.total = ordenDto.total;
                            neworden.Activo = true;
                        };
                        context.Orden.Add(neworden);
                        context.SaveChanges();
                        return neworden;
                    }
                }
            }
        }
    }
    public interface IOrdenService
    {
        List<OrdenViewModel> GetListOrden();
        Orden Create(OrdenDto ordenDto);
    }
}
