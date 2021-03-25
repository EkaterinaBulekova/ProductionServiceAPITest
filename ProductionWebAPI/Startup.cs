using System.IO;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ProductionWebAPI.Startup))]

namespace ProductionWebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var envFilePath = System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, ".env");
            if (File.Exists(envFilePath))
            {
                DotNetEnv.Env.Load(envFilePath);
            }

            var corsOptions = CorsConfig.ConfigureCors(Settings.AllowedOrigins);
            app.UseCors(corsOptions);

            HttpConfiguration config = new HttpConfiguration();

            config.Filters.Add(new ExceptionFilter());

            AutofacConfig.Configure(config);

            FormatterConfig.Configure(config);
            RouteConfig.Configure(config);
            LoggerConfig.Configure(config);
            OptionsMessageHandlerConfig.Configure(config);
            SwaggerConfig.Configure(config);

            app.UseAutofacMiddleware(AutofacConfig.Container);
            app.UseAutofacWebApi(config);

            app.PreventResponseCaching();

            app.UseAuthentication();
            app.UseWebApi(config);
        }
    }
}
