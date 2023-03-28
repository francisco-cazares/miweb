    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Domain.Dto;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class Carro_ProductoController : Controller
    {
        private readonly ICarro_ProductoService _Carro_ProductoService;

        public Carro_ProductoController(ICarro_ProductoService Carro_ProductoService)
        {
            _Carro_ProductoService = Carro_ProductoService;
        }
        [HttpGet]
        public ActionResult GetListCarro_Producto()
        {
            try
            {
                var result = _Carro_ProductoService.GetListCarro_Producto();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]

        public ActionResult CreateCarro_Producto(Carro_ProductoDto carro_productoDto)
        {
            try
            {
                var result = _Carro_ProductoService.Create(carro_productoDto);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public ActionResult UpdateCarro_Producto(Carro_ProductoDto carro_productoDto)
        {
            try
            {
                _Carro_ProductoService.Update(carro_productoDto);
                return Json("Ok");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


