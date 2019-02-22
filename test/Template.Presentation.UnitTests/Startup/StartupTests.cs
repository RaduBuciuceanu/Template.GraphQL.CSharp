using System;
using System.Linq;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Template.Business.Commands.Logging;
using Template.Business.Commands.Messages;
using Template.Business.Repositories;
using Template.Data.Commands;
using Template.Data.Mapping;
using Template.Data.Repositories;
using Template.Presentation.GraphQL.Main;
using Template.Presentation.GraphQL.Nodes.Types;
using Xunit;
using CreateMessageCommand = Template.Business.Commands.Messages.CreateMessage;
using CreateMessageMutation = Template.Presentation.GraphQL.Nodes.Mutations.CreateMessage;
using GetMessagesCommand = Template.Business.Commands.Messages.GetMessages;
using GetMessagesQuery = Template.Presentation.GraphQL.Nodes.Queries.GetMessages;
using MessageCreatedCommand = Template.Business.Commands.Messages.MessageCreated;
using MessageCreatedSubscription = Template.Presentation.GraphQL.Nodes.Subscriptions.MessageCreated;

namespace Template.Presentation.UnitTests.Startup
{
    public abstract class StartupTests
    {
        private readonly IServiceProvider _provider;

        protected abstract Action<IServiceCollection> Act { get; }

        protected StartupTests()
        {
            var collection = new ServiceCollection();
            Act(collection);
            _provider = collection.BuildServiceProvider();
        }

        [Fact]
        public void ConfigureServices_DataIAutomapper_IsRegistered()
        {
            Get<IAutomapper>().ShouldBeOfType<Automapper>();
        }

        [Fact]
        public void ConfigureServices_ILogger_IsRegistered()
        {
            Get<ILogger>().ShouldBeOfType<Logger>();
        }

        [Fact]
        public void ConfigureServices_ILogRepository_IsRegistered()
        {
            Get<ILogRepository>().ShouldBeOfType<LogRepository>();
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
        public void ConfigureServices_IFilterMessages_IsRegistered()
        {
            Get<IFilterMessages>().ShouldBeOfType<FilterMessages>();
        }

        [Fact]
        public void ConfigureServices_ICreatePagination_IsRegistered()
        {
            Get<ICreatePagination<object>>().ShouldBeOfType<CreatePagination<object>>();
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
            Get<Schema, GraphSchema>().ShouldNotBeNull();
        }

        protected TService Get<TService>()
        {
            return _provider.GetService<TService>();
        }

        protected TService Get<TService, TImplementation>()
        {
            return _provider.GetServices<TService>().Single(instance => instance is TImplementation);
        }
    }
}
