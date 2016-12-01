using Microsoft.Practices.Unity;
using WebServicesProject.Logic;

namespace WebServicesProject
{
    public static class UnityConfig
    {
        public static IUnityContainer Configure()
        {
            var container = new UnityContainer();

            container.RegisterType<ProductoLogic, ProductoLogic>();

            return container;
        }
    }
}