using System;
using System.Collections.Generic;
using GraphQL.Business.Commands;
using GraphQL.Presentation.GraphQL;
using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using CreateMessage = GraphQL.Presentation.GraphQL.Mutations.CreateMessage;
using MutationNode = GraphQL.Presentation.GraphQL.Main.Mutation;
using SubscriptionNode = GraphQL.Presentation.GraphQL.Main.Subscription;
using QueryNode = GraphQL.Presentation.GraphQL.Main.Query;

namespace GraphQL.Presentation.Ioc
{
    public class GraphModule : IModule
    {
        public void Configure(IServiceCollection collection)
        {
            collection.AddScoped(BuildMutations);

            collection.AddScoped<MutationNode>();
            collection.AddScoped<SubscriptionNode>();
            collection.AddScoped<QueryNode>();
            collection.AddScoped<Schema, GraphSchema>();
        }

        private static IEnumerable<IMutation> BuildMutations(IServiceProvider provider)
        {
            return new IMutation[]
            {
                new CreateMessage(provider.GetService<ICreateMessage>()),
            };
        }
    }
}