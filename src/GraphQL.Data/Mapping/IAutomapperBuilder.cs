namespace GraphQL.Data.Mapping
{
    public interface IAutomapperBuilder
    {
        IAutomapperBuilder WithMaps();

        IAutomapper Build();
    }
}
