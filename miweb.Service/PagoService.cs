﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miweb.Domain.Dto;
using miweb.Domain.Model;
using miweb.Persistence.dataBase;
using static miweb.Service.PagoService;

namespace miweb.Service
{
    public class PagoService : IPagoService
    {
        public List<PagoViewModel> GetListPago()
        {
            using (var context = new ecommerceEntities1())
            {
                List<PagoViewModel> lista = (from _pag in context.Pago
                                             where _pag.Activo == true
                                             select new PagoViewModel
                                             {
                                                 PagoId = _pag.PagoId,
                                                 Nombre = _pag.Nombre,
                                                 Imagen = _pag.Imagen,
                                                 Activo = _pag.Activo
                                             }).ToList();
                return lista;

            }
        }
        public Pago Create(PagoDto pagoDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Pago pago = context.Pago.FirstOrDefault
                    (pag => pag.Nombre.ToUpper().Trim() == pagoDto.Nombre.ToUpper().Trim());
                {
                    if (pago?.Activo == true)
                    {
                        throw new Exception($"Pago ya esta realizado");
                    }
                    else if (pago?.Activo == false)
                    {
                        pago.Activo = true;

                        context.Entry(pago).State = EntityState.Modified;
                        context.SaveChanges();
                        return pago;
                    }
                    else
                    {
                        var newpago = new Pago();
                        {
                            newpago.Nombre = pagoDto.Nombre;
                            newpago.Imagen = pagoDto.Imagen;
                            newpago.Activo = true;
                        };
                        context.Pago.Add(newpago);
                        context.SaveChanges();
                        return newpago;
                    }
                }
            }
        }
        public void Update(PagoDto pagoDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Pago actualizar = context.Pago.FirstOrDefault
                   (p => p.Nombre.ToUpper().Trim() == pagoDto.Nombre.ToUpper().Trim());
                {
                    if (actualizar == null)
                    {
                        throw new Exception($"Pago no se encuentra registrado");
                    }
                    else
                    {
                        actualizar.Nombre = pagoDto.Nombre;
                        actualizar.Imagen = pagoDto.Imagen;
                        actualizar.Activo = true;


                        context.Entry(actualizar).State = EntityState.Modified;
                        context.SaveChanges();

                    }
                }
            }
        }
    }


    public interface IPagoService
    {
        List<PagoViewModel> GetListPago();
        Pago Create(PagoDto pagoDto);
        void Update(PagoDto pagoDto);
    }

   
}