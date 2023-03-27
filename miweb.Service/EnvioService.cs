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
    public class EnvioService : IEnvioService
    {
        public List<EnvioViewModel> GetListEnvio()
        {
            using (var context = new ecommerceEntities1())
            {
                List<EnvioViewModel> lista = (from _Env in context.Envio
                                              where _Env.Activo == true
                                              select new EnvioViewModel
                                              {
                                                  EnvId = _Env.EnvId,
                                                  Nombre = _Env.Nombre,
                                                  Imagen = _Env.Imagen,
                                                  Costo = _Env.Costo,
                                                  Activo = _Env.Activo
                                              }).ToList();
                return lista;
            }
        }
        public Envio Create(EnvioDto envioDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Envio envio = context.Envio.FirstOrDefault(e => e.Nombre.ToUpper().Trim() == envioDto.Nombre.ToUpper().Trim());
                {
                    if (envio?.Activo == true)
                    {
                        throw new Exception($"Envio ya se encuentra registrado");
                    }
                    else if (envio?.Activo == false)
                    {
                        envio.Activo = true;

                        context.Entry(envio).State = EntityState.Modified;
                        context.SaveChanges();
                        return (envio);
                    }
                    else
                    {
                        var newenvio = new Envio();
                        {
                            newenvio.Nombre = envioDto.Nombre;
                            newenvio.Imagen = envioDto.Imagen;
                            newenvio.Costo = envioDto.Costo;
                            newenvio.Activo = true;
                        };
                        context.Envio.Add(newenvio);
                        context.SaveChanges();
                        return newenvio;
                    }
                }
            }

        }
        public void Update(EnvioDto envioDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Envio actualizar = context.Envio.FirstOrDefault
                    (e => e.Nombre.ToUpper().Trim() == envioDto.Nombre.ToUpper().Trim());
                {
                    if (actualizar == null)
                    {
                        throw new Exception($"Envio no se encuentra registrado");
                    }
                    else
                    {
                        actualizar.Nombre = envioDto.Nombre;
                        actualizar.Imagen = envioDto.Imagen;
                        actualizar.Costo = envioDto.Costo;
                        actualizar.Activo = true;


                        context.Entry(actualizar).State = EntityState.Modified;
                        context.SaveChanges();

                    }

                }
            }
        }
    }

        public interface IEnvioService
        {
            List<EnvioViewModel> GetListEnvio();
            Envio Create(EnvioDto envioDto);

         void Update(EnvioDto envioDto);


        }
    
}
