using SimpleInjector;
using SimpleInjector.Packaging;
using Interfaces;

namespace Services.DI
{
    public class UserServicesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IUser, UserService>();
        }
    }
}
