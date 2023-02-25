﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class Cliente_DireccionController : Controller
    {

        private readonly ICliente_DireccionService _Cliente_DireccionService;
        public Cliente_DireccionController(ICliente_DireccionService Cliente_DireccionService)
        {
            _Cliente_DireccionService = Cliente_DireccionService;
        }
        [HttpGet]

        public ActionResult GetListCliente_Direccion()
        {
            try
            {
                var result = _Cliente_DireccionService.GetListCliente_Direccion();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


