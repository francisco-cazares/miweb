using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miweb.Domain.Model;
using miweb.Persistence.dataBase;

namespace miweb.Service
{
    public class OrdenService : IOrdenService
    {
        public List<OrdenViewModel> GetListOrden()
        {
            using (var context = new ecommerceEntities1())
            {
                List<OrdenViewModel> lista = (from _Ord in context.Orden
                                              where _Ord.Activo == true
                                              select new OrdenViewModel
                                              {
                                                  Ordid = _Ord.Ordid,
                                                  ClienteId = _Ord.ClienteId,
                                                  DirId = _Ord.DirId,
                                                  PagoId = _Ord.PagoId,
                                                  EnvId = _Ord.EnvId,
                                                  total = _Ord.total,
                                                  Activo = _Ord.Activo
                                              }).ToList();
                return lista;
            }
        }
    }
    public interface IOrdenService
    {
        List<OrdenViewModel> GetListOrden();
    }
}
