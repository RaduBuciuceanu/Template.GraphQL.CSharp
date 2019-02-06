﻿using GraphQL.Business;
using Microsoft.AspNetCore.Builder;

namespace GraphQL.Presentation.Main.Configurations
{
    public interface IConfigureDevelopment : ICommand<IApplicationBuilder, IApplicationBuilder>
    {
    }
}