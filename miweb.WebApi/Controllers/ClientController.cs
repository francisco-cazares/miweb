using miweb.Domain.Dto;
using miweb.Service;
using System;
using System.Web.Mvc;

namespace miweb.WebApi.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult GetListClient()
        {
            try
            {
                var result = _clientService.GetListClient();

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult CreateCliente(ClienteDto clienteDto)
        {
            try
            {
                var result = _clientService.Create(clienteDto);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult UpdateCliente(ClienteDto clienteDto)
        {
            try
            {
                _clientService.Update(clienteDto);
                return Json("Ok");
            }
            catch (Exception ex)    
            {
                throw ex;
            }
        }
    }
}