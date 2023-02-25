using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miweb.Domain.Model;
using miweb.Persistence.dataBase;


namespace miweb.Service
{
    public class CarroService :ICarroService
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
}
    public interface ICarroService
    {
        List<CarroViewModel> GetListCarro();
    }
}
