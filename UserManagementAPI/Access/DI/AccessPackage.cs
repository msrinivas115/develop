using SimpleInjector;
using SimpleInjector.Packaging;

namespace Access.DI
{
    public class AccessPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IUserAccess, UserAccess>();
        }
    }
}
