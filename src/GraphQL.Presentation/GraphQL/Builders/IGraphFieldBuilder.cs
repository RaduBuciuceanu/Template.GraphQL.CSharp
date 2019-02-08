using GraphQL.Presentation.GraphQL.Contract;
using GraphQL.Types;

namespace GraphQL.Presentation.GraphQL.Builders
{
    public interface IGraphFieldBuilder
    {
        IGraphFieldBuilder WithNode(IHasBasics basic);

        FieldType Build();
    }
}
