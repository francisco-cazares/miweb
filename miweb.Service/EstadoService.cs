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
    public class EstadoService : IEstadoService
    {
        public List<EstadoViewModel> GetListEstado()
        {
            using (var context = new ecommerceEntities1())
            {
                List<EstadoViewModel> lista = (from _Est in context.Estado
                                              where _Est.Activo == true
                                              select new EstadoViewModel
                                              {
                                                  EstId = _Est.EstId,
                                                  Nombre = _Est.Nombre,
                                                  PaisID = _Est.PaisID,
                                                  Activo = _Est.Activo,
                                              }).ToList();
                return lista;
            }
        }
        public Estado Create(EstadoDto estadoDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Estado estado = context.Estado.FirstOrDefault
                    (env => env.Nombre.ToUpper().Trim() == estadoDto.Nombre.ToUpper().Trim());
                {
                    if (estado?.Activo == true)
                    {
                        throw new Exception($"Estado ya existe");
                    }
                    else if (estado?.Activo == false)
                    {
                        estado.Activo = true;

                        context.Entry(estado).State = EntityState.Modified;
                        context.SaveChanges();
                        return (estado);
                    }
                    else
                    {
                        var newestado = new Estado();
                        {
                            newestado.Nombre = estadoDto.Nombre;
                            newestado.PaisID = estadoDto.PaisID;
                            newestado.Activo = true;
                        };
                        context.Estado.Add(newestado);
                        context.SaveChanges();
                        return newestado;
                    }
                }
            }
        }
        public void Update(EstadoDto estadoDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Estado actualizar = context.Estado.FirstOrDefault
                        (est => est.Nombre.ToUpper().Trim() == estadoDto.Nombre.ToUpper().Trim());
                {
                    if (actualizar == null)
                    {
                        throw new Exception($"Estado no se encuentra registrado");
                    }
                    else
                    {
                        actualizar.Nombre = estadoDto.Nombre;
                        actualizar.PaisID = estadoDto.PaisID;
                        actualizar.Activo = true;


                        context.Entry(actualizar).State = EntityState.Modified;
                        context.SaveChanges();

                    }


                }
            }
        }
    }
 
    public interface IEstadoService
    {
        List<EstadoViewModel> GetListEstado();
        Estado Create(EstadoDto estadoDto);

        void Update(EstadoDto estadoDto);
    }
}
