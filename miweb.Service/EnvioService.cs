using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
    public interface IEnvioService
    {
        List<EnvioViewModel> GetListEnvio();
    }
}
