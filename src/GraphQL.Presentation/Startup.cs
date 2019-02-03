using GraphiQl;
using GraphQL.Presentation.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddMvc();
            collection.AddCors();

            IModule modules = new Modules();
            modules.Configure(collection);
        }

        public void Configure(IApplicationBuilder builder, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                builder.UseDeveloperExceptionPage();
            }

            builder.UseGraphiQl();
            builder.UseMvc();
        }
    }
}