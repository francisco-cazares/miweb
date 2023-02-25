using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miweb.Domain.Model;
using miweb.Persistence.dataBase;

namespace miweb.Service
{
    public class CategoryService : ICategoryService
    {
        public List<CategoryViewModel> GetListCategory()
        {
            using (var context = new ecommerceEntities1())
            {
                List<CategoryViewModel> lista = (from _cat in context.Categoria
                                                 where _cat.Activo == true
                                                 select new CategoryViewModel
                                                 {
                                                     CatId = _cat.CatId,
                                                     Nombre = _cat.Nombre,
                                                     Imagen = _cat.Imagen,
                                                     Descripcion = _cat.Descripcion,
                                                     Activo = _cat.Activo
                                                 }).ToList();
                return lista;
            }
        }
    }
    public interface ICategoryService
    {
        List<CategoryViewModel> GetListCategory();
    }
}

