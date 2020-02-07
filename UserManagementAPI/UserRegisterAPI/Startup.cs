using Access.DI;
using Microsoft.Owin;
using Owin;
using Services.DI;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using UserRegisterAPI.Claims;

[assembly: OwinStartup(typeof(UserRegisterAPI.Startup))]

namespace UserRegisterAPI
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
            container.Register<ICliam, Cliams>();
            container.RegisterPackages(new[] { typeof(AccessPackage).Assembly });
            container.RegisterPackages(new[] { typeof(UserServicesPackage).Assembly });
            container.Verify();
        }
    }
}
