using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using GraphQL.Business;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using CreateMessage = GraphQL.Presentation.GraphQL.Mutations.CreateMessage;
using GetMessages = GraphQL.Presentation.GraphQL.Queries.GetMessages;
using GraphSchema = GraphQL.Presentation.GraphQL.GraphSchema;
using ICreateMessageCommand = GraphQL.Business.Commands.ICreateMessage;
using IMessageCreatedCommand = GraphQL.Business.Commands.IMessageCreated;
using IMutation = GraphQL.Presentation.GraphQL.Contract.IMutation;
using IQuery = GraphQL.Presentation.GraphQL.Contract.IQuery;
using ISubscription = GraphQL.Presentation.GraphQL.Contract.ISubscription;
using MessageCreated = GraphQL.Presentation.GraphQL.Subscriptions.MessageCreated;
using MutationNode = GraphQL.Presentation.GraphQL.Main.Mutation;
using QueryNode = GraphQL.Presentation.GraphQL.Main.Query;
using SubscriptionNode = GraphQL.Presentation.GraphQL.Main.Subscription;

namespace GraphQL.Presentation.Ioc
{
    internal class ConfigureGraph : Command<IServiceCollection, IServiceCollection>, IConfigureServices
    {
        public override IObservable<IServiceCollection> Execute(IServiceCollection input)
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
