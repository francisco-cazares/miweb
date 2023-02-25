using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

    }
}
    


        
 
