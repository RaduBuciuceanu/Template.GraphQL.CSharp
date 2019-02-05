using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using GraphQL.Presentation.GraphQL;
using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Presentation.GraphQL.Mutations;
using GraphQL.Presentation.GraphQL.Queries;
using GraphQL.Presentation.GraphQL.Subscriptions;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using ICreateMessageCommand = GraphQL.Business.Commands.ICreateMessage;
using IMessageCreatedCommand = GraphQL.Business.Commands.IMessageCreated;
using MutationNode = GraphQL.Presentation.GraphQL.Main.Mutation;
using QueryNode = GraphQL.Presentation.GraphQL.Main.Query;
using SubscriptionNode = GraphQL.Presentation.GraphQL.Main.Subscription;

namespace GraphQL.Presentation.Ioc.Modules
{
    internal class ConfigureGraph : IConfigureServices
    {
        public IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddScoped(BuildMutations))
                .Do(services => services.AddScoped(BuildQueries))
                .Do(services => services.AddScoped(BuildSubscriptions))
                .Do(services => services.AddScoped<MutationNode>())
                .Do(services => services.AddScoped<QueryNode>())
                .Do(services => services.AddScoped<SubscriptionNode>())
                .Do(services => services.AddScoped<Schema, GraphSchema>());
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
                new CreateMessage(provider.GetService<ICreateMessageCommand>())
            };
        }

        private static IEnumerable<ISubscription> BuildSubscriptions(IServiceProvider provider)
        {
            return new ISubscription[]
            {
                new MessageCreated(provider.GetService<IMessageCreatedCommand>())
            };
        }
    }
}
