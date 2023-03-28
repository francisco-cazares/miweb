using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Domain.Dto;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _ProductoService;
        public ProductoController(IProductoService ProductoService)
        {
            _ProductoService = ProductoService;
        }
        [HttpGet]

        public ActionResult GetListProducto()
        {
          try
            {
                var result = _ProductoService.GetListProducto();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult CreateProducto(ProductoDto productoDto)
        {
            try
            {
                var result = _ProductoService.Create(productoDto);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public ActionResult UpdateProducto(ProductoDto productoDto)
        {
            try
            {
                _ProductoService.Update(productoDto);
                return Json("Ok");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}