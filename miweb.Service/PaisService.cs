using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
        public interface IPaisService
        {
            List<PaisViewModel> GetListPais();
        }
    }
