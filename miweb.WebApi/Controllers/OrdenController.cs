using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Domain.Dto;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class OrdenController : Controller
    {
        private readonly IOrdenService _OrdenService;

        public OrdenController(IOrdenService OrdenService)
        {
            _OrdenService = OrdenService;
        }
        [HttpGet]

        public ActionResult GetListOrden()
        {
            try
            {
                var result = _OrdenService.GetListOrden();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult CreateOrden(OrdenDto ordenDto)
        {
            try
            {
                var result = _OrdenService.Create(ordenDto);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public ActionResult UpdateOrden(OrdenDto ordenDto)
        {
            try
            {
                _OrdenService.Update(ordenDto);
                return Json("Ok");  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}



