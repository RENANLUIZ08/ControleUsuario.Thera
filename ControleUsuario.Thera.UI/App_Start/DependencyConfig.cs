using ControleUsuario.Thera.Service.Implementations;
using ControleUsuario.Thera.Service.Interface;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace ControleUsuario.Thera.UI.App_Start
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new UnityContainer();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IRegistroService, RegistroService>();
            AutoMapperConfig.Configure(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}