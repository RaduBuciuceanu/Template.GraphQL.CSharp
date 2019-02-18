using System.Linq;
using GraphQL.Presentation.GraphQL.Main;
using GraphQL.Presentation.GraphQL.Nodes.Types;
using GraphQL.Presentation.GraphQL.Nodes.Types.Base;
using GraphQL.Types;
using Moq;
using Shouldly;
using Xunit;

namespace GraphQL.Presentation.UnitTests.GraphQL.Main
{
    public class SubscriptionNodeTests
    {
        private readonly ISubscription _subscription;
        private readonly IHasArgument _hasArgument;
        private readonly Node<ISubscription> _instance;

        public SubscriptionNodeTests()
        {
            _subscription = BuildSubscription();
            _hasArgument = (IHasArgument)_subscription;
            _instance = new Node<ISubscription>(new[] { _subscription });
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameName()
        {
            _instance.Fields.ShouldContain(field => field.Name == _subscription.Name);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameDescription()
        {
            _instance.Fields.ShouldContain(field => field.Description == _subscription.Description);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameType()
        {
            _instance.Fields.ShouldContain(field => field.Type == _subscription.Type);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentType()
        {
            _instance.Fields.ShouldContain(field => field.Arguments.First().Type == _hasArgument.ArgumentType);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentName()
        {
            _instance.Fields.ShouldContain(field => field.Arguments.First().Name == _hasArgument.ArgumentName);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentDescription()
        {
            _instance.Fields.ShouldContain(
                field => field.Arguments.First().Description == _hasArgument.ArgumentDescription);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithResolver()
        {
            _instance.Fields.ShouldContain(field => field.Resolver != null);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSubscriber()
        {
            _instance.Fields.ShouldContain(field => ((EventStreamFieldType)field).Subscriber != null);
        }

        private ISubscription BuildSubscription()
        {
            var mock = new Mock<ISubscription>();

            mock.Setup(mutation => mutation.Name).Returns("subscriptionName");
            mock.Setup(mutation => mutation.Description).Returns("Random description here.");
            mock.Setup(mutation => mutation.Type).Returns(typeof(ObjectGraphType));

            SetupHasArgument(mock);

            return mock.Object;
        }

        private void SetupHasArgument(Mock<ISubscription> mock)
        {
            var hasArgument = mock.As<IHasArgument>();
            hasArgument.Setup(mutation => mutation.ArgumentType).Returns(typeof(InputObjectGraphType));
            hasArgument.Setup(mutation => mutation.ArgumentName).Returns("argumentName");
            hasArgument.Setup(mutation => mutation.ArgumentDescription).Returns("Random argument description here.");
        }
    }
}
