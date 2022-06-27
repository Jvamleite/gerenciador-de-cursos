using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace GerenciadorDeCursos.API
{
    public class Program
    {
        private static string currentEnvironment;

        public static int Main(string[] args)
        {
            try
            {
                currentEnvironment = string.Empty;

                var hostBuilder = CreateHostBuilder(args).Build();
                Log.Warning("Iniciando API. Ambiente: " + currentEnvironment);
                hostBuilder.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host encerrado inesperadamente. Ambiente: " + currentEnvironment);
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
           .ConfigureAppConfiguration((builderContext, config) =>
           {
               var env = builderContext.HostingEnvironment;
               currentEnvironment = env.EnvironmentName;
               var settings = config.Build();
               Log.Logger = new LoggerConfiguration()
                  .Enrich.FromLogContext()
                  .MinimumLevel.Debug()
                  .WriteTo.Console()
                  .CreateLogger();
           })
           .UseSerilog()
           .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.UseStartup<Startup>();
           });

            return hostBuilder;
        }
    }
}