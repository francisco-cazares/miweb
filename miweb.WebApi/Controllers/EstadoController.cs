using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Domain.Dto;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class EstadoController : Controller
    {
        private readonly IEstadoService _EstadoService;

        public EstadoController(IEstadoService EstadoService)
        {
            _EstadoService = EstadoService;
        }
        [HttpGet]
        public ActionResult GetListEstado()
        {
            try
            {
                var result = _EstadoService.GetListEstado();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]

        public ActionResult CreateEstado(EstadoDto estadoDto)
        {
            try
            {
                var result = _EstadoService.Create(estadoDto);  
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

