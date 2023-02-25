using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class Orden_ProductoController : Controller
    {

        private readonly IOrden_ProductoService _Orden_ProductoService;

        public Orden_ProductoController(IOrden_ProductoService Orden_ProductoService)
        {
            _Orden_ProductoService = Orden_ProductoService;
        }
        [HttpGet]
        public ActionResult GetListOrden_Producto()
        {
            try
            {
                var result = _Orden_ProductoService.GetListOrden_Producto();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

        