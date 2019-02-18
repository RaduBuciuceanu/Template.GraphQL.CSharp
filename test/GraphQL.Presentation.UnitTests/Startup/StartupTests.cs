using System;
using System.Linq;
using GraphQL.Business.Commands;
using GraphQL.Business.Repositories;
using GraphQL.Data.Mapping;
using GraphQL.Data.Repositories;
using GraphQL.Presentation.GraphQL.Main;
using GraphQL.Presentation.GraphQL.Nodes.Types;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;
using CreateMessageCommand = GraphQL.Business.Commands.CreateMessage;
using CreateMessageMutation = GraphQL.Presentation.GraphQL.Nodes.Mutations.CreateMessage;
using GetMessagesCommand = GraphQL.Business.Commands.GetMessages;
using GetMessagesQuery = GraphQL.Presentation.GraphQL.Nodes.Queries.GetMessages;
using MessageCreatedCommand = GraphQL.Business.Commands.MessageCreated;
using MessageCreatedSubscription = GraphQL.Presentation.GraphQL.Nodes.Subscriptions.MessageCreated;

namespace GraphQL.Presentation.UnitTests.Startup
{
    public abstract class StartupTests
    {
        private static readonly IServiceCollection Collection = new ServiceCollection();

        protected abstract Action<IServiceCollection> Act { get; }

        protected StartupTests()
        {
            if (!Collection.Any())
            {
                Act(Collection);
            }
        }

        [Fact]
        public void ConfigureServices_DataIAutomapper_IsRegistered()
        {
            Get<IAutomapper>().ShouldBeOfType<Automapper>();
        }

        [Fact]
        public void ConfigureServices_IMessageRepository_IsRegistered()
        {
            Get<IMessageRepository>().ShouldBeOfType<MessageRepository>();
        }

        [Fact]
        public void ConfigureServices_IMessageCreated_IsRegistered()
        {
            Get<IMessageCreated>().ShouldBeOfType<MessageCreatedCommand>();
        }

        [Fact]
        public void ConfigureServices_ICreateMessage_IsRegistered()
        {
            Get<ICreateMessage>().ShouldBeOfType<CreateMessageCommand>();
        }

        [Fact]
        public void ConfigureServices_IGetMessages_IsRegistered()
        {
            Get<IGetMessages>().ShouldBeOfType<GetMessagesCommand>();
        }

        [Fact]
        public void ConfigureServices_CreateMessageMutation_IsRegistered()
        {
            Get<IMutation, CreateMessageMutation>().ShouldNotBeNull();
        }

        [Fact]
        public void ConfigureServices_GetMessagesQuery_IsRegistered()
        {
            Get<IQuery, GetMessagesQuery>().ShouldNotBeNull();
        }

        [Fact]
        public void ConfigureServices_MessageCreatedSubscription_IsRegistered()
        {
            Get<ISubscription, MessageCreatedSubscription>().ShouldNotBeNull();
        }

        [Fact]
        public void ConfigureServices_MutationNode_IsRegistered()
        {
            Get<Node<IMutation>>().ShouldNotBeNull();
        }

        [Fact]
        public void ConfigureServices_QueryNode_IsRegistered()
        {
            Get<Node<IQuery>>().ShouldNotBeNull();
        }

        [Fact]
        public void ConfigureServices_SubscriptionNode_IsRegistered()
        {
            Get<Node<ISubscription>>().ShouldNotBeNull();
        }

        [Fact]
        public void ConfigureServices_Schema_IsRegistered()
        {
            Collection.ShouldContain(instance => instance.ServiceType == typeof(Schema));
        }

        protected TService Get<TService>()
        {
            IServiceProvider provider = Collection.BuildServiceProvider();
            return provider.GetService<TService>();
        }

        protected TService Get<TService, TImplementation>()
        {
            IServiceProvider provider = Collection.BuildServiceProvider();
            return provider.GetServices<TService>().Single(instance => instance is TImplementation);
        }
    }
}
