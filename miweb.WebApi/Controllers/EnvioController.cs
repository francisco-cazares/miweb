using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Domain.Dto;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class EnvioController : Controller
    {
        private readonly IEnvioService _EnvioService;
        public EnvioController(IEnvioService EnvioService)
        {
            _EnvioService = EnvioService;
        }
        [HttpGet]
        public ActionResult GetListEnvio()
        {
            try
            {
                var result = _EnvioService.GetListEnvio();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        [HttpPost]

        public ActionResult CreateEnvio(EnvioDto envioDto)
        {
            try
            {
                var result = _EnvioService.Create(envioDto);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
