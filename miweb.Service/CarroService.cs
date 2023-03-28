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
    public class CarroService : ICarroService
    {
        public List<CarroViewModel> GetListCarro()
        {
            using (var context = new ecommerceEntities1())
            {
                List<CarroViewModel> lista = (from _Car in context.Carro
                                              where _Car.Activo == true
                                              select new CarroViewModel
                                              {
                                                  CarroId = _Car.CarroId,
                                                  CliId = _Car.CliId,
                                                  DirId = _Car.DirId,
                                                  PagoId = _Car.PagoId,
                                                  EnvId = _Car.EnvId,
                                                  Total = _Car.Total,
                                                  Activo = _Car.Activo
                                              }).ToList();
                return lista;
            }
        }

        public Carro Create(CarroDto carroDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Carro carro = context.Carro.FirstOrDefault
                    (ca => ca.PagoId == carroDto.PagoId);
                {
                    if (carro?.Activo == true)
                    {
                        throw new Exception($"Automovil ya vendido");
                    }
                    else if (carro?.Activo == false)
                    {
                        carro.Activo = true;

                        context.Entry(carro).State = EntityState.Modified;
                        context.SaveChanges();
                        return carro;
                    }
                    else
                    {
                        var newcarro = new Carro();
                        {
                            newcarro.CliId = carroDto.CliId;
                            newcarro.DirId = carroDto.DirId;
                            newcarro.PagoId = carroDto.PagoId;
                            newcarro.EnvId = carroDto.EnvId;
                            newcarro.Total = carroDto.Total;
                            newcarro.Activo = true;
                        }
                        context.Carro.Add(newcarro);
                        context.SaveChanges();
                        return newcarro;
                    }

                }
            }


        }
        public void Update(CarroDto carroDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Carro actualizar = context.Carro.FirstOrDefault
                   (c => c.CliId == carroDto.CliId && c.PagoId == carroDto.PagoId);
                {
                    if (actualizar == null)
                    {
                        throw new Exception($"Producto no se encuentra registrado");
                    }
                    else
                    {
                       
                        actualizar.CliId = carroDto.CliId;
                        actualizar.DirId = carroDto.DirId;
                        actualizar.PagoId = carroDto.PagoId;
                        actualizar.EnvId = carroDto.EnvId;
                        actualizar.Total = carroDto.Total;

                        actualizar.Activo = true;


                        context.Entry(actualizar).State = EntityState.Modified;
                        context.SaveChanges();

                    }


                }
            }
        }
    }

    public interface ICarroService
    {
        List<CarroViewModel> GetListCarro();

        Carro Create(CarroDto carroDto);

        void Update(CarroDto carroDto);
    }
}