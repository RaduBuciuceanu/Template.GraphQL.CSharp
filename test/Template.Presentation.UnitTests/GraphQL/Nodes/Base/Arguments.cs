namespace Template.Presentation.UnitTests.GraphQL.Nodes.Base
{
    internal static class Arguments
    {
        private const string Mutation = "GraphQL/Nodes/Mutations/Arguments";
        private const string Queries = "GraphQL/Nodes/Queries/Arguments";
        private const string Subscriptions = "GraphQL/Nodes/Subscriptions/Arguments";

        public static readonly string MessageInput = $"{Mutation}/MessageInput.json";
        public static readonly string GetMessagesParameter = $"{Queries}/GetMessagesParameter.json";
        public static readonly string MessageCreatedParameter = $"{Subscriptions}/MessageCreatedParameter.json";
    }
}
