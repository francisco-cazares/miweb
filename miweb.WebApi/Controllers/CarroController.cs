using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Domain.Dto;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class CarroController : Controller
    {
        private readonly ICarroService _CarroService;

        public CarroController(ICarroService CarroService)
        {
            _CarroService = CarroService;
        }
        [HttpGet]

        public ActionResult GetListCarro()
        {
            try
            {
                var result = _CarroService.GetListCarro();
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        
        public ActionResult CreateCarro(CarroDto carroDto)
        {
            try
            {
                var result = _CarroService.Create(carroDto);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


