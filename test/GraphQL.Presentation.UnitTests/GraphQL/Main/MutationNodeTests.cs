using System.Linq;
using GraphQL.Presentation.GraphQL.Main;
using GraphQL.Presentation.GraphQL.Nodes.Types;
using GraphQL.Types;
using Moq;
using Shouldly;
using Xunit;

namespace GraphQL.Presentation.UnitTests.GraphQL.Main
{
    public class MutationNodeTests
    {
        private readonly Mock<IMutation> _mutationMock;
        private readonly Node<IMutation> _instance;

        private IMutation Mutation => _mutationMock.Object;

        public MutationNodeTests()
        {
            _mutationMock = BuildMutationMock();
            _instance = new Node<IMutation>(new[] { Mutation });
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameName()
        {
            _instance.Fields.ShouldAllBe(field => field.Name == Mutation.Name);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameDescription()
        {
            _instance.Fields.ShouldAllBe(field => field.Description == Mutation.Description);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameType()
        {
            _instance.Fields.ShouldAllBe(field => field.Type == Mutation.Type);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentType()
        {
            _instance.Fields.ShouldAllBe(field => field.Arguments.First().Type == Mutation.ArgumentType);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentName()
        {
            _instance.Fields.ShouldAllBe(field => field.Arguments.First().Name == Mutation.ArgumentName);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentDescription()
        {
            _instance.Fields.ShouldAllBe(field => field.Arguments.First().Description == Mutation.ArgumentDescription);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithResolver()
        {
            var context = new ResolveFieldContext();

            _instance.Fields.First().Resolver.Resolve(context);

            _mutationMock.Verify(mutation => mutation.Resolve(context));
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithoutSubscriber()
        {
            _instance.Fields.ShouldAllBe(field => ((EventStreamFieldType)field).Subscriber == null);
        }

        private static Mock<IMutation> BuildMutationMock()
        {
            var mock = new Mock<IMutation>();

            mock.Setup(mutation => mutation.Name).Returns("mutationName");
            mock.Setup(mutation => mutation.Description).Returns("Random description here.");
            mock.Setup(mutation => mutation.Type).Returns(typeof(ObjectGraphType));
            mock.Setup(mutation => mutation.ArgumentType).Returns(typeof(InputObjectGraphType));
            mock.Setup(mutation => mutation.ArgumentName).Returns("argumentName");
            mock.Setup(mutation => mutation.ArgumentDescription).Returns("Random argument description here.");

            return mock;
        }
    }
}
