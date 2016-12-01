using Microsoft.AspNet.Identity;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Unity.WebApi;
using Swashbuckle.Application;
using WebServicesProject.App_Start;

namespace WebServicesProject
{
    public class Startup
    {
        public static IUnityContainer unityContainer { get; set; }
        public void Configuration(IAppBuilder appBuilder)
        {
            //Configurar unittu (inyeccion de dependencias)
            unityContainer = UnityConfig.Configure();

            //Definir que se use cors para evitar inconvenietes de requests de diferentes dominios
            appBuilder.UseCors(CorsOptions.AllowAll);

            //Configurar NHibernate (ORM)
            appBuilder.Use<NhibernateMiddleware>(unityContainer);

            // Forma de autenticacion.
            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                AuthenticationMode = AuthenticationMode.Active,
                CookieName = ".ASPXFORMSAUTH",
                SlidingExpiration = true,
            });

            // Crear el objeto HttpConfiguration.
            var httpConfiguration = ConfigureAspNetWebApi();

            //Agrega Middleware WebApi
            appBuilder.UseWebApi(httpConfiguration);

            ConfigureSwagger(httpConfiguration);
        }

        protected HttpConfiguration ConfigureAspNetWebApi()
        {
            var config = new HttpConfiguration();
            // Web API routes
            config.MapHttpAttributeRoutes();
            //configure the JSON formatter to avoid serializing enums as numbers when JSON is returned (instead of strings as in XML)
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;

            //register the dependency resolver for the Unity container
            config.DependencyResolver = new UnityDependencyResolver(unityContainer);

            return config;
        }

        protected static string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\bin\WebServicesProject.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }

        protected void ConfigureSwagger(HttpConfiguration configuration)
        {
            Func<HttpRequestMessage, string> rootUrlResolver = req =>
                $"{req.RequestUri.GetLeftPart(UriPartial.Authority)}{VirtualPathUtility.ToAbsolute("~/").TrimEnd('/')}";

            configuration.EnableSwagger(docConfig =>
            {
                docConfig.RootUrl(rootUrlResolver);
                docConfig.SingleApiVersion("v1", "Ejemplo Web Service")
                    .Description("Desarrollo de Aplicaciones Cliente Servidor")
                    .Contact(cc => cc
                        .Email("lucaskloster@gmail.com"));
                docConfig.IncludeXmlComments(GetXmlCommentsPath());
                docConfig.UseFullTypeNameInSchemaIds();
            })
                .EnableSwaggerUi();
        }
    }
}