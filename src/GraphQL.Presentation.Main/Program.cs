using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GraphQL.Presentation.Main
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
                .UseKestrel()
                .UseStartup(assemblyName);
        }
    }
}
