using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Domain.Dto;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class PaisController : Controller
    {
        private readonly IPaisService _PaisService;

        public PaisController(IPaisService PaisService)
        {
            _PaisService = PaisService;
        }
        [HttpGet]
        public ActionResult GetListPais()
        {
                try
                {
                var result = _PaisService.GetListPais();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        [HttpPost]
        public ActionResult CreatePais(PaisDto paisDto)
        {
            try
            {
                var result = _PaisService.Create(paisDto);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public ActionResult UpdatePais(PaisDto paisDto)
        {
            try
            {
                _PaisService.Update(paisDto);
                return Json("Ok");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
    


        
 
