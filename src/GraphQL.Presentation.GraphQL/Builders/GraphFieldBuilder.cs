using System;
using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace GraphQL.Presentation.GraphQL.Builders
{
    internal class GraphFieldBuilder
    {
        private readonly EventStreamFieldType _instance;

        private INode _node;

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
                .WithHasArgument(_node as IArgumentNode)
                .WithResolver(new FuncFieldResolver<object>(_node.Resolve))
                .WithSubscriber(_node as ISubscription);

            return _instance;
        }

        public GraphFieldBuilder WithNode(INode node)
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

        private GraphFieldBuilder WithHasArgument(IArgumentNode argumentNode)
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

        private static QueryArgument BuildQueryArgument(IArgumentNode argumentNode)
        {
            return new QueryArgument(argumentNode.ArgumentType)
            {
                Name = argumentNode.ArgumentName,
                Description = argumentNode.ArgumentDescription
            };
        }
    }
}

