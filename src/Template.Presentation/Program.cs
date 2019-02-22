using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Template.Presentation
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            string assemblyName = typeof(Program).Assembly.FullName;

            return WebHost
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .UseKestrel()
                .UseStartup(assemblyName);
        }

        private static void ConfigureAppConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            const string settingsFolder = "Settings";
            string settingsFile = $"appsettings.{context.HostingEnvironment.EnvironmentName}.json";
            builder.AddJsonFile(Path.Combine(settingsFolder, settingsFile), true);
        }
    }
}
