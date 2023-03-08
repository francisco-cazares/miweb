using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Domain.Dto;
using miweb.Service;


namespace miweb.WebApi.Controllers
{
    public class DireccionController : Controller
    {
        private readonly IDireccionService _DireccionService;

        public DireccionController(IDireccionService DireccionService)
        {
            _DireccionService = DireccionService;
        }
        [HttpGet]

        public ActionResult GetListDireccion()
        {
            try
            {
                var result = _DireccionService.GetListDireccion();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]

        public ActionResult CreateDireccion(DireccionDto direccionDto)
        {
            try 
            {
                var result = _DireccionService.Create(direccionDto);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
