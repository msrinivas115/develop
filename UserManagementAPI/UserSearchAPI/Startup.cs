using Access.DI;
using Microsoft.Owin;
using Owin;
using Services.DI;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using UserSearchAPI.Claims;

[assembly: OwinStartup(typeof(UserSearchAPI.Startup))]

namespace UserSearchAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            // Invoke the ConfigureAuth method, which will set up
            // the OWIN authentication pipeline using OAuth 2.0
            ConfigureAuth(app);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            RegisterPackages(container);

            HttpConfiguration config = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            };
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        private void RegisterPackages(Container container)
        {
            container.Register<ICliam, Cliam>();
            container.RegisterPackages(new[] { typeof(AccessPackage).Assembly });
            container.RegisterPackages(new[] { typeof(UserServicesPackage).Assembly });
            container.Verify();
        }
    }
}
