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
    public class DireccionService : IDireccionService
    {
        public List<DireccionViewModel> GetListDireccion()
        {
            using (var context = new ecommerceEntities1())
            {
                List<DireccionViewModel> lista = (from _Dir in context.Direccion
                                                  where _Dir.Activo == true
                                              select new DireccionViewModel
                                              {
                                                  Dirid = _Dir.Dirid,
                                                  calle = _Dir.calle,
                                                  numero = _Dir.numero,
                                                  colonia = _Dir.colonia,
                                                  cp = _Dir.cp,
                                                  EstadoId = _Dir.EstadoId,
                                                  entre_calles =_Dir.entre_calles,
                                                  referencias =_Dir.referencias,
                                                  Activo = _Dir.Activo
                                              }).ToList();
                return lista;
            }
        }
        public Direccion Create (DireccionDto direccionDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Direccion direccion = context.Direccion.FirstOrDefault
                    (d => d.numero == direccionDto.numero);
                {
                    if (direccion?.Activo == true)
                    {
                        throw new Exception($"Direccion ya registrada");
                    }
                    else if (direccion?.Activo == false)
                    {
                        direccion.Activo = true;

                        context.Entry(direccion).State = EntityState.Modified;
                        context.SaveChanges();
                        return direccion;
                    }
                    else
                    {
                        var newdireccion = new Direccion();
                        {
                            newdireccion.calle = direccionDto.calle;
                            newdireccion.numero = direccionDto.numero;
                            newdireccion.colonia = direccionDto.colonia;
                            newdireccion.cp = direccionDto.cp;
                            newdireccion.EstadoId = direccionDto.EstadoId;
                            newdireccion.entre_calles = direccionDto.entre_calles;
                            newdireccion.referencias = direccionDto.referencias;
                            newdireccion.Activo = direccionDto.Activo;
                        };
                        context.Direccion.Add(newdireccion);
                        context.SaveChanges();
                        return newdireccion;
                    }
                }
            }
           
        }

    }
    public interface IDireccionService
    {
        List<DireccionViewModel> GetListDireccion();
        Direccion Create(DireccionDto direccionDto);
    }
}
