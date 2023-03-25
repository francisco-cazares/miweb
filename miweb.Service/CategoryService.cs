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
        public Categoria Create (CategoriaDto categoriaDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Categoria categoria = context.Categoria.FirstOrDefault
                     (cat => cat.Nombre.ToUpper().Trim() == categoriaDto.Nombre.ToUpper().Trim());

                if (categoria?.Activo == true)
                {
                    throw new Exception($"Ya existe Categoria");
                }
                else if (categoria?.Activo == false)
                {
                    categoria.Activo = true;

                    context.Entry(categoria).State = EntityState.Modified;
                    context.SaveChanges();
                    return categoria;
                }
                else
                {
                    var newcategoria = new Categoria();
                    {
                        newcategoria.Nombre = categoriaDto.Nombre;
                        newcategoria.Imagen = categoriaDto.Imagen;
                        newcategoria.Descripcion = categoriaDto.Descripcion;
                        newcategoria.Activo = true;
                    };
                    context.Categoria.Add(newcategoria);
                    context.SaveChanges();
                    return newcategoria;

                }   
            }
        }

        public void Update(CategoriaDto categoriaDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Categoria actualizar = context.Categoria.FirstOrDefault
                    (cat => cat.Nombre.ToUpper().Trim() == categoriaDto.Nombre.ToUpper().Trim());
                {
                    if (actualizar == null)
                    {
                        throw new Exception($"Categoria no se encuentra registrado");
                    }
                    else
                    {
                        actualizar.Nombre = categoriaDto.Nombre;
                        actualizar.Imagen = categoriaDto.Imagen;
                        actualizar.Descripcion = categoriaDto.Descripcion;
                        actualizar.Activo =true;
                      

                        context.Entry(actualizar).State = EntityState.Modified;
                        context.SaveChanges();

                    }


                }
            }
        }
    }
    public interface ICategoryService
    {
        List<CategoryViewModel> GetListCategory();
        Categoria Create (CategoriaDto categoriaDto);

        void Update(CategoriaDto categoriaDto);
    }
}

