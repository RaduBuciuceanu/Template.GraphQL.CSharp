﻿using System.Reactive.Linq;
using GraphiQl;
using GraphQL.Presentation.Startup.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Startup
{
    public class StartupDevelopment
    {
        public static void ConfigureServices(IServiceCollection collection)
        {
            collection.AddMvc();

            new Settings().Execute(collection).Wait();
            new MemoryStorages().Execute(collection).Wait();
            new DataMapping().Execute(collection).Wait();
            new BusinessRepositories().Execute(collection).Wait();
            new BusinessCommands().Execute(collection).Wait();
            new Graph().Execute(collection).Wait();
        }

        public static void Configure(IApplicationBuilder builder)
        {
            builder.UseMvc();
            builder.UseGraphiQl();
            builder.UseDeveloperExceptionPage();
        }
    }
}
