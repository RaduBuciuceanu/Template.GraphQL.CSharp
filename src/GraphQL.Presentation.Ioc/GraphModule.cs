using System;
using System.Collections.Generic;
using GraphQL.Presentation.GraphQL;
using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Presentation.GraphQL.Queries;
using GraphQL.Presentation.GraphQL.Subscriptions;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using CreateMessage = GraphQL.Presentation.GraphQL.Mutations.CreateMessage;
using MutationNode = GraphQL.Presentation.GraphQL.Main.Mutation;
using SubscriptionNode = GraphQL.Presentation.GraphQL.Main.Subscription;
using QueryNode = GraphQL.Presentation.GraphQL.Main.Query;
using IMessageCreatedCommand = GraphQL.Business.Commands.IMessageCreated;
using ICreateMessageCommand = GraphQL.Business.Commands.ICreateMessage;

namespace GraphQL.Presentation.Ioc
{
    public class GraphModule : IModule
    {
        public void Configure(IServiceCollection collection)
        {
            collection.AddScoped(BuildMutations);
            collection.AddScoped(BuildQueries);
            collection.AddScoped(BuildSubscriptions);

            collection.AddScoped<MutationNode>();
            collection.AddScoped<SubscriptionNode>();
            collection.AddScoped<QueryNode>();
            collection.AddScoped<Schema, GraphSchema>();
        }

        private static IEnumerable<IQuery> BuildQueries(IServiceProvider provider)
        {
            return new IQuery[]
            {
                new GetMessages()
            };
        }

        private static IEnumerable<IMutation> BuildMutations(IServiceProvider provider)
        {
            return new IMutation[]
            {
                new CreateMessage(provider.GetService<ICreateMessageCommand>()),
            };
        }

        private static IEnumerable<ISubscription> BuildSubscriptions(IServiceProvider provider)
        {
            return new ISubscription[]
            {
                new MessageCreated(provider.GetService<IMessageCreatedCommand>()),
            };
        }
    }
}

