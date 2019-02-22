using GraphQL.Types;
using Template.Presentation.UnitTests.GraphQL.Nodes.Base;

namespace Template.Presentation.UnitTests.GraphQL.Nodes
{
    public abstract class HasArgumentTests<TArgumentModel, TContext> where TContext : ResolveFieldContext<object>, new()
    {
        protected TContext Context { get; }

        protected TArgumentModel ExpectedArgument { get; }

        protected HasArgumentTests(string argumentName, string argumentJsonPath)
        {
            var builder = new ContextBuilder<TContext>();
            Context = builder.WithJson(argumentJsonPath).Build();
            ExpectedArgument = Context.GetArgument<TArgumentModel>(argumentName);
        }
    }
}
