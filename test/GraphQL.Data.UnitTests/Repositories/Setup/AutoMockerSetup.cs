using Moq.AutoMock;

namespace GraphQL.Data.UnitTests.Repositories.Setup
{
    public abstract class AutoMockerSetup
    {
        protected AutoMocker Mocker { get; }

        protected AutoMockerSetup(AutoMocker mocker)
        {
            Mocker = mocker;
        }
    }
}
