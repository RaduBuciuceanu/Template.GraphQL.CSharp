using System.Linq;
using System.Reactive.Linq;
using GraphQL.Presentation.GraphQL.Main;
using GraphQL.Presentation.GraphQL.Nodes.Types;
using GraphQL.Presentation.GraphQL.Nodes.Types.Base;
using GraphQL.Subscription;
using GraphQL.Types;
using Moq;
using Shouldly;
using Xunit;

namespace GraphQL.Presentation.UnitTests.GraphQL.Main
{
    public class SubscriptionNodeTests
    {
        private readonly ResolveEventStreamContext _streamContext = new ResolveEventStreamContext();
        private readonly Mock<ISubscription> _subscriptionMock;
        private readonly Node<ISubscription> _instance;

        private ISubscription Subscription => _subscriptionMock.Object;

        private IHasArgument HasArgument => (IHasArgument)Subscription;

        public SubscriptionNodeTests()
        {
            _subscriptionMock = BuildSubscription();
            _instance = new Node<ISubscription>(new[] { Subscription });
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameName()
        {
            _instance.Fields.ShouldAllBe(field => field.Name == Subscription.Name);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameDescription()
        {
            _instance.Fields.ShouldAllBe(field => field.Description == Subscription.Description);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameType()
        {
            _instance.Fields.ShouldAllBe(field => field.Type == Subscription.Type);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentType()
        {
            _instance.Fields.ShouldAllBe(field => field.Arguments.First().Type == HasArgument.ArgumentType);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentName()
        {
            _instance.Fields.ShouldAllBe(field => field.Arguments.First().Name == HasArgument.ArgumentName);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentDescription()
        {
            _instance.Fields.ShouldAllBe(
                field => field.Arguments.First().Description == HasArgument.ArgumentDescription);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithResolver()
        {
            var context = new ResolveFieldContext();

            _instance.Fields.First().Resolver.Resolve(context);

            _subscriptionMock.Verify(subscription => subscription.Resolve(context), Times.Once);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSubscriber()
        {
            var field = (EventStreamFieldType)_instance.Fields.First();

            field.Subscriber.Subscribe(_streamContext).Wait();

            _subscriptionMock.Verify(subscription => subscription.Subscribe(_streamContext), Times.Once);
        }

        private Mock<ISubscription> BuildSubscription()
        {
            var mock = new Mock<ISubscription>();

            mock.Setup(mutation => mutation.Name).Returns("subscriptionName");
            mock.Setup(mutation => mutation.Description).Returns("Random description here.");
            mock.Setup(mutation => mutation.Type).Returns(typeof(ObjectGraphType));
            mock.Setup(mutation => mutation.Subscribe(_streamContext)).Returns(Observable.Return(new object()));

            SetupHasArgument(mock);

            return mock;
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
