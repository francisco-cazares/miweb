using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miweb.Service;

namespace miweb.WebApi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController (ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
       [HttpGet]
        public ActionResult GetListCategory()
        {
            try
            {
                var result = _CategoryService.GetListCategory();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}