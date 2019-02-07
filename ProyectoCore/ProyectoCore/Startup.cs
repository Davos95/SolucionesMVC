using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.TraceListener;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.AzureAppServices;
using Microsoft.Extensions.Logging.Console;
using ProyectoCore.Data;
using ProyectoCore.Models;
using ProyectoCore.Repositories;

namespace ProyectoCore
{
    public class Startup
    {
        IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //EN LOS SERVICIOS ES DIBDE SE REALIZA LA INVERSION DE CONTROL IoC
            String cadenaConexion = this.configuration.GetConnectionString("cadenaHospital");
            //String cadenaConexionMySQL = this.configuration.GetConnectionString("cadenaHospitalMySQL");
            String cadenaConexionAzure = this.configuration.GetConnectionString("cadenaHospitalAzure");

            //PARA PONER UN OBJETO EN LA APP PARA QUE RESUELVA LAS DEPENDENCIAS, SE HACE CON AddTransient
            services.AddTransient<IRepositoryHospital, RepositoryHospital>();
 
            services.AddDbContext<IHospitalContext, HospitalContext>(options => options.UseSqlServer(cadenaConexionAzure));

            //services.AddDbContext<IHospitalContext, HospitalContextMySQL>(options => options.UseMySql(cadenaConexionMySQL));


            //RESOLVEMOS LAS DEPENDENCIAS CON IoC
            //services.AddTransient<ICoche, Deportivo>();

            //Y si puedieramos personalizar un coche?
            //El coche que instanciemos...
            services.AddSingleton<ICoche, Deportivo>(z => new Deportivo("ToFast","ToFurious","coche_azul.jpg",300));

            //CONFIGURAMOS LA POLITICA DE COOKIES
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //CONFIGURAMOS EL COMPORTAMIENTO DEL SESSION
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            //DEBEMOS INDICAR QUE ARRANQUE EL SERVICIO DEL 
            //MIDELWARE
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {

            //CREAMOS NUESTRO PROVEEDOR PARA EL LOGGER
            //loggerfactory.AddProvider(new ConsoleLoggerProvider(
            //    (categoria, nivel) => nivel >= LogLevel.Information, false)
            //    );

            ////PODEMOS CREAR DE FORMA EXPLICITA UN LOGGER
            //ILogger log = loggerfactory.CreateLogger<ConsoleLogger>();

            ////MOSTRAMOS MENSAJES
            //log.LogInformation("Mensaje desde StartUp Configuration");

            loggerfactory.AddAzureWebAppDiagnostics(
                new AzureAppServicesDiagnosticsSettings
                {
                    OutputTemplate = "{Timestamp:dd-MM-yyyy HH:mm:ss zzz} [{Level}] {RequestId}-{SourceContext}: {Message}{NewLine}{Exception}"
                }
            );

            Trace.Listeners.Add(new ApplicationInsightsTraceListener());


            //1. CONTROL DE ERRORES
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //4. UTILIZAMOS ARCHIVOS DE wwwroot
            app.UseStaticFiles();

            //5. POLITICA DE COOKIES
            app.UseCookiePolicy();

            //7. UTILIZAMOS LA SESION
            app.UseSession();


            //8. DEBEMOS DAR LA RUTA DE INICIO
            //CONFIGURAMOS LAS AREAS
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=RealMadrid}/{action=Index}/{id?}"
                );
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
