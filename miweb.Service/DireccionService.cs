using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
    public interface IDireccionService
    {
        List<DireccionViewModel> GetListDireccion();
    }
}
