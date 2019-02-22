using System.Collections.Generic;
using Moq.AutoMock;
using Shouldly;
using Template.Presentation.GraphQL.Main;
using Template.Presentation.GraphQL.Nodes.Types;
using Xunit;

namespace Template.Presentation.UnitTests.GraphQL.Main
{
    public class GraphSchemaTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly GraphSchema _instance;

        public GraphSchemaTests()
        {
            SetupNodes();
            _instance = _mocker.CreateInstance<GraphSchema>();
        }

        [Fact]
        public void Constructor_Mutation_IsSet()
        {
            _instance.Mutation.ShouldBe(_mocker.Get<Node<IMutation>>());
        }

        [Fact]
        public void Constructor_MutationName_IsSet()
        {
            _instance.Mutation.Name.ShouldBe("mutation");
        }

        [Fact]
        public void Constructor_Query_IsSet()
        {
            _instance.Query.ShouldBe(_mocker.Get<Node<IQuery>>());
        }

        [Fact]
        public void Constructor_QueryName_IsSet()
        {
            _instance.Query.Name.ShouldBe("query");
        }

        [Fact]
        public void Constructor_Subscription_IsSet()
        {
            _instance.Subscription.ShouldBe(_mocker.Get<Node<ISubscription>>());
        }

        [Fact]
        public void Constructor_SubscriptionName_IsSet()
        {
            _instance.Subscription.Name.ShouldBe("subscription");
        }

        private void SetupNodes()
        {
            _mocker.Use(new Node<IMutation>(new List<IMutation>()));
            _mocker.Use(new Node<IQuery>(new List<IQuery>()));
            _mocker.Use(new Node<ISubscription>(new List<ISubscription>()));
        }
    }
}
