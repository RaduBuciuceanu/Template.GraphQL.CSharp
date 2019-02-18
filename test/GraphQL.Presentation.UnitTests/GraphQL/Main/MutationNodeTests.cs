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
        private readonly IMutation _mutation;
        private readonly Node<IMutation> _instance;

        public MutationNodeTests()
        {
            _mutation = BuildMutation();
            _instance = new Node<IMutation>(new[] { _mutation });
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameName()
        {
            _instance.Fields.ShouldContain(field => field.Name == _mutation.Name);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameDescription()
        {
            _instance.Fields.ShouldContain(field => field.Description == _mutation.Description);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameType()
        {
            _instance.Fields.ShouldContain(field => field.Type == _mutation.Type);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentType()
        {
            _instance.Fields.ShouldContain(field => field.Arguments.First().Type == _mutation.ArgumentType);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentName()
        {
            _instance.Fields.ShouldContain(field => field.Arguments.First().Name == _mutation.ArgumentName);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithSameArgumentDescription()
        {
            _instance.Fields.ShouldContain(
                field => field.Arguments.First().Description == _mutation.ArgumentDescription);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithResolver()
        {
            _instance.Fields.ShouldContain(field => field.Resolver != null);
        }

        [Fact]
        public void Constructor_ChildNodeIsSet_WithoutSubscriber()
        {
            _instance.Fields.ShouldContain(field => ((EventStreamFieldType)field).Subscriber == null);
        }

        private IMutation BuildMutation()
        {
            var mock = new Mock<IMutation>();

            mock.Setup(mutation => mutation.Name).Returns("mutationName");
            mock.Setup(mutation => mutation.Description).Returns("Random description here.");
            mock.Setup(mutation => mutation.Type).Returns(typeof(ObjectGraphType));
            mock.Setup(mutation => mutation.ArgumentType).Returns(typeof(InputObjectGraphType));
            mock.Setup(mutation => mutation.ArgumentName).Returns("argumentName");
            mock.Setup(mutation => mutation.ArgumentDescription).Returns("Random argument description here.");

            return mock.Object;
        }
    }
}
