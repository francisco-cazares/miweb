using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Domain.Dto;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class PagoController : Controller
    {
        private readonly IPagoService _PagoService;

        public PagoController(IPagoService PagoService)
        {
            _PagoService = PagoService;
        }
        [HttpGet]

        public ActionResult GetListPago()
        {
            try
            {
                var result = _PagoService.GetListPago();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]

        public ActionResult CreatePago(PagoDto pagoDto)
        {
            try
            {
                var result = _PagoService.Create(pagoDto);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public ActionResult UpdatePago(PagoDto pagoDto)
        {
            try
            {
                _PagoService.Update(pagoDto);
                return Json("Ok");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
  