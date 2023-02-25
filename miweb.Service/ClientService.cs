using miweb.Domain.Model;
using miweb.Persistence.dataBase;
using System;
using System.Collections.Generic;
using System.Linq;




namespace miweb.Service
{
    public class ClientService : IClientService
    {
        public List<ClientViewModel> GetListClient()
        {
    
            using (var context = new ecommerceEntities1())
            {

               List<ClientViewModel> lista = (from _cli in context.Cliente where _cli.Activo == true
                         select new ClientViewModel
                         {
                             ClienteId = _cli.ClienteId,
                             Nombre = _cli.Nombre,
                             Contrasena = _cli.Contrasena,
                             Email = _cli.Email,
                             Rol = _cli.Rol,
                             Telefono = _cli.Telefono,
                             Activo = _cli.Activo
                         }).ToList();

                return lista;
            }
        }

    }

    public interface IClientService
    {
        List<ClientViewModel> GetListClient();
    }
}
