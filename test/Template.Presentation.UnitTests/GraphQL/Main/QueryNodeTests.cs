using System.Linq;
using GraphQL.Types;
using Moq;
using Shouldly;
using Template.Presentation.GraphQL.Main;
using Template.Presentation.GraphQL.Nodes.Types;
using Template.Presentation.GraphQL.Nodes.Types.Base;
using Xunit;

namespace Template.Presentation.UnitTests.GraphQL.Main
{
    public class QueryNodeTests
    {
        private readonly Mock<IQuery> _queryMock;
        private readonly Node<IQuery> _instance;

        private IQuery Query => _queryMock.Object;

        private IHasArgument HasArgument => (IHasArgument)Query;

        public QueryNodeTests()
        {
            _queryMock = BuildQueryMock();
            _instance = new Node<IQuery>(new[] { Query });
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameName()
        {
            _instance.Fields.ShouldAllBe(field => field.Name == Query.Name);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameDescription()
        {
            _instance.Fields.ShouldAllBe(field => field.Description == Query.Description);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameType()
        {
            _instance.Fields.ShouldAllBe(field => field.Type == Query.Type);
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

            _queryMock.Verify(query => query.Resolve(context), Times.Once);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithoutSubscriber()
        {
            _instance.Fields.ShouldContain(field => ((EventStreamFieldType)field).Subscriber == null);
        }

        private static Mock<IQuery> BuildQueryMock()
        {
            var mock = new Mock<IQuery>();

            mock.Setup(mutation => mutation.Name).Returns("queryName");
            mock.Setup(mutation => mutation.Description).Returns("Random description here.");
            mock.Setup(mutation => mutation.Type).Returns(typeof(ObjectGraphType));

            SetupHasArgument(mock);

            return mock;
        }

        private static void SetupHasArgument(Mock<IQuery> mock)
        {
            var hasArgument = mock.As<IHasArgument>();
            hasArgument.Setup(mutation => mutation.ArgumentType).Returns(typeof(InputObjectGraphType));
            hasArgument.Setup(mutation => mutation.ArgumentName).Returns("argumentName");
            hasArgument.Setup(mutation => mutation.ArgumentDescription).Returns("Random argument description here.");
        }
    }
}
