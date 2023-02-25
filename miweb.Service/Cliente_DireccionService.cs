using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miweb.Domain.Model;
using miweb.Persistence.dataBase;

namespace miweb.Service
{
    public class Cliente_DireccionService : ICliente_DireccionService
    {
        public List<Cliente_DireccionViewModel> GetListCliente_Direccion()
        {
            using (var context = new ecommerceEntities1())
            {
                List<Cliente_DireccionViewModel> lista = (from _CD in context.Cliente_Direccion
                                                          where _CD.Activo == true
                                                          select new Cliente_DireccionViewModel
                                                          {
                                                              CDid = _CD.CDid,
                                                              CliId = _CD.CliId,
                                                              DirId = _CD.DirId,
                                                              Activo = _CD.Activo
                                                          }).ToList();
                return lista;
            }
        }
    }
    public interface ICliente_DireccionService
    {
        List<Cliente_DireccionViewModel> GetListCliente_Direccion();
    }
}
