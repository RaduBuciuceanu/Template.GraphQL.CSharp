using System;
using GraphQL.Resolvers;
using GraphQL.Types;
using Template.Presentation.GraphQL.Nodes.Types;
using Template.Presentation.GraphQL.Nodes.Types.Base;

namespace Template.Presentation.GraphQL.Main
{
    internal class GraphFieldBuilder
    {
        private readonly EventStreamFieldType _instance;

        private IHasBasics _node;

        public GraphFieldBuilder()
        {
            _instance = new EventStreamFieldType();
        }

        public FieldType Build()
        {
            WithName(_node.Name)
                .WithDescription(_node.Description)
                .WithType(_node.Type)
                .WithDefaultArguments()
                .WithHasArgument(_node as IHasArgument)
                .WithResolver(new FuncFieldResolver<object>(_node.Resolve))
                .WithSubscriber(_node as ISubscription);

            return _instance;
        }

        public GraphFieldBuilder WithNode(IHasBasics node)
        {
            _node = node;
            return this;
        }

        private GraphFieldBuilder WithName(string name)
        {
            _instance.Name = name;
            return this;
        }

        private GraphFieldBuilder WithDescription(string description)
        {
            _instance.Description = description;
            return this;
        }

        private GraphFieldBuilder WithType(Type type)
        {
            _instance.Type = type;
            return this;
        }

        private GraphFieldBuilder WithDefaultArguments()
        {
            _instance.Arguments = new QueryArguments(Array.Empty<QueryArgument>());
            return this;
        }

        private GraphFieldBuilder WithHasArgument(IHasArgument argumentNode)
        {
            if (argumentNode != null)
            {
                _instance.Arguments.Add(BuildQueryArgument(argumentNode));
            }

            return this;
        }

        private GraphFieldBuilder WithResolver(IFieldResolver resolver)
        {
            _instance.Resolver = resolver;
            return this;
        }

        private GraphFieldBuilder WithSubscriber(ISubscription node)
        {
            if (node != null)
            {
                _instance.Subscriber = new EventStreamResolver<object>(node.Subscribe);
            }

            return this;
        }

        private static QueryArgument BuildQueryArgument(IHasArgument argumentNode)
        {
            return new QueryArgument(argumentNode.ArgumentType)
            {
                Name = argumentNode.ArgumentName,
                Description = argumentNode.ArgumentDescription
            };
        }
    }
}
