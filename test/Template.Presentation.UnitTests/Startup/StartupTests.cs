using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Template.Business.Commands.Logging;
using Template.Business.Commands.Messages;
using Template.Business.Commands.Status;
using Template.Business.Repositories;
using Template.Data.Commands.Messages;
using Template.Data.Commands.Pagination;
using Template.Data.Commands.Status;
using Template.Data.Mapping;
using Template.Data.Repositories;
using Template.Presentation.Commands;
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
            IServiceCollection collection = BuildServiceCollection();
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
        public void Configure_IGetDataComponentHealth_IsRegistered()
        {
            Get<IEnumerable<IGetComponentHealth>>().ShouldContain(instance => instance is GetComponentHealth);
        }

        [Fact]
        public void Configure_IGetApplicationVersion_IsRegistered()
        {
            Get<IGetApplicationVersion>().ShouldBeOfType<GetApplicationVersion>();
        }

        [Fact]
        public void Configure_IGetApplicationHealth_IsRegistered()
        {
            Get<IGetApplicationHealth>().ShouldBeOfType<GetApplicationHealth>();
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
        public void ConfigureServices_IStatusRepository_IsRegistered()
        {
            Get<IStatusRepository>().ShouldBeOfType<StatusRepository>();
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

        private static IServiceCollection BuildServiceCollection()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<IHostingEnvironment, HostingEnvironment>();
            return collection;
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
