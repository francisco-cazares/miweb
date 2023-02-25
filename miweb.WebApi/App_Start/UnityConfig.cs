using miweb.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace miweb.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

          
            container.RegisterType<IOrden_ProductoService, Orden_ProductoService>();
            container.RegisterType<IOrdenService, OrdenService>();
            container.RegisterType<ICarro_ProductoService, Carro_ProductoService>();
            container.RegisterType<ICarroService, CarroService>();
            container.RegisterType<ICliente_DireccionService, Cliente_DireccionService>();
            container.RegisterType<IDireccionService, DireccionService>();
            container.RegisterType<IProductoService, ProductoService>();
            container.RegisterType<IEstadoService, EstadoService>();
            container.RegisterType<IEnvioService, EnvioService>();
            container.RegisterType<IPagoService, PagoService>();
            container.RegisterType<IPaisService, PaisService>();
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<ICategoryService, CategoryService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}