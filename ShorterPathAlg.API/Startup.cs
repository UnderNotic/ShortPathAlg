using System.Reflection;
using Autofac;
using Autofac.Integration.SignalR;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using ShorterPathAlg;

[assembly: OwinStartup(typeof(Startup))]
namespace ShorterPathAlg
{
    using System.Web.Http;
    using Microsoft.Owin;
    using Microsoft.Owin.Extensions;
    using Microsoft.Owin.FileSystems;
    using Microsoft.Owin.StaticFiles;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();

            // Configure Web API Routes:
            // - Enable Attribute Mapping
            // - Enable Default routes at /api.
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.Routes.MapHttpRoute(
                name: "AlgorithmApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterHubs(Assembly.GetExecutingAssembly());

            var config = new HubConfiguration();

            Bootstrap(builder);

            var container = builder.Build();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.Resolver = new AutofacDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(httpConfiguration);
            app.UseWebApi(httpConfiguration);

            app.MapSignalR("/signalr", config);

            // Make ./public the default root of the static files in our Web Application.
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = new PathString(string.Empty),
                FileSystem = new PhysicalFileSystem("./public"),
                EnableDirectoryBrowsing = true,
            });

            app.UseStageMarker(PipelineStage.MapHandler);
        }

        private void Bootstrap(ContainerBuilder builder)
        {
            builder.RegisterHubs(Assembly.GetExecutingAssembly());
        }
    }
}
