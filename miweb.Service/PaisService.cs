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
    public class PaisService : IPaisService
    {
        public List<PaisViewModel> GetListPais()
        {
            using (var context = new ecommerceEntities1())
            {
                List<PaisViewModel> lista = (from _Pa in context.Pais
                                             where _Pa.Activo == true
                                             select new PaisViewModel
                                             {
                                                 paisID = _Pa.paisID,
                                                 Nombre = _Pa.Nombre,
                                                 Activo = _Pa.Activo
                                             }).ToList();
                return lista;
            }
        }
        public Pais Create(PaisDto paisDto)
        {
            using (var context = new ecommerceEntities1())
            {
                var pais = context.Pais.FirstOrDefault(p => p.Nombre.ToUpper().Trim() == paisDto.Nombre.Trim().ToUpper());

                if (pais?.Activo == true)
                {
                    throw new Exception($"Ya existe un pais");
                }
                else if (pais?.Activo == false)
                {   
                    pais.Activo = true;

                    context.Entry(pais).State = EntityState.Modified;
                    context.SaveChanges();
                    return pais;
                }
                else
                {
                    var newPais = new Pais()
                    {
                        Nombre = paisDto.Nombre,
                        Activo = true;
                    };
                    context.Pais.Add(newPais);
                    context.SaveChanges();
                    return newPais;
                }

            }
        }
    }
    public interface IPaisService
    {
        List<PaisViewModel> GetListPais();
        Pais Create(PaisDto paisDto);

    }
}
