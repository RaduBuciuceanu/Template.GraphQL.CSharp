namespace Template.Data.Mapping
{
    public interface IAutomapperBuilder
    {
        IAutomapperBuilder WithMaps();

        IAutomapper Build();
    }
}
