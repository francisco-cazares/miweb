using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
    public interface IEstadoService
    {
        List<EstadoViewModel> GetListEstado();
    }
}
