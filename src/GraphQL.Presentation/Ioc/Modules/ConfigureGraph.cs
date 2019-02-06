using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using CreateMessage = GraphQL.Presentation.Main.GraphQL.Mutations.CreateMessage;
using GetMessages = GraphQL.Presentation.Main.GraphQL.Queries.GetMessages;
using GraphSchema = GraphQL.Presentation.Main.GraphQL.GraphSchema;
using ICreateMessageCommand = GraphQL.Business.Commands.ICreateMessage;
using IMessageCreatedCommand = GraphQL.Business.Commands.IMessageCreated;
using IMutation = GraphQL.Presentation.Main.GraphQL.Contract.IMutation;
using IQuery = GraphQL.Presentation.Main.GraphQL.Contract.IQuery;
using ISubscription = GraphQL.Presentation.Main.GraphQL.Contract.ISubscription;
using MessageCreated = GraphQL.Presentation.Main.GraphQL.Subscriptions.MessageCreated;
using MutationNode = GraphQL.Presentation.Main.GraphQL.Main.Mutation;
using QueryNode = GraphQL.Presentation.Main.GraphQL.Main.Query;
using SubscriptionNode = GraphQL.Presentation.Main.GraphQL.Main.Subscription;

namespace GraphQL.Presentation.Main.Ioc.Modules
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
