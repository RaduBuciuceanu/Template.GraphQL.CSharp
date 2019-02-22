using System.Reactive.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Moq;
using Moq.AutoMock;
using Shouldly;
using Template.Business.Commands.Messages;
using Template.Business.Models.Parameters;
using Template.Presentation.GraphQL.Types;
using Template.Presentation.UnitTests.GraphQL.Nodes.Base;
using Xunit;
using GetMessages = Template.Presentation.GraphQL.Nodes.Queries.GetMessages;
using GetMessagesParameterModel = Template.Business.Models.Parameters.GetMessagesParameter;
using MessagePaginationModel = Template.Business.Models.Pagination<Template.Business.Models.Message>;

namespace Template.Presentation.UnitTests.GraphQL.Nodes.Queries
{
    public class GetMessagesTests : HasArgumentTests<GetMessagesParameter, ResolveFieldContext>
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly MessagePaginationModel _expectedResult = new MessagePaginationModel();
        private readonly GetMessages _instance;

        private GetMessagesParameterModel _actualArgument;

        public GetMessagesTests() : base("parameter", Arguments.GetMessagesParameter)
        {
            SetupCommand();
            _instance = _mocker.CreateInstance<GetMessages>();
        }

        [Fact]
        public void Constructor_Type_IsSet()
        {
            bool actual = typeof(Pagination<Message>).IsAssignableFrom(_instance.Type);

            actual.ShouldBeTrue();
        }

        [Fact]
        public void Constructor_Name_IsSet()
        {
            _instance.Name.ShouldBe("getMessages");
        }

        [Fact]
        public void Constructor_Description_IsSet()
        {
            _instance.Description.ShouldBe("Returns all the existent messages.");
        }

        [Fact]
        public void Constructor_ArgumentName_IsSet()
        {
            _instance.ArgumentName.ShouldBe("parameter");
        }

        [Fact]
        public void Constructor_ArgumentDescription_IsSet()
        {
            _instance.ArgumentDescription.ShouldBe("The parameter used to filter the messages.");
        }

        [Fact]
        public void Constructor_ArgumentType_IsSet()
        {
            _instance.ArgumentType.ShouldBe(typeof(Presentation.GraphQL.Types.Parameters.GetMessagesParameter));
        }

        [Fact]
        public async Task Resolve_InvokesCommand_WithRightId()
        {
            await (Task<MessagePaginationModel>)_instance.Resolve(Context);

            _actualArgument.Id.ShouldBe(ExpectedArgument.Id);
        }

        [Fact]
        public async Task Resolve_ReturnsResult_FromGetMessagesCommand()
        {
            var actual = await (Task<MessagePaginationModel>)_instance.Resolve(Context);

            actual.ShouldBe(_expectedResult);
        }

        private void SetupCommand()
        {
            _mocker.GetMock<IGetMessages>()
                .Setup(command => command.Execute(It.IsAny<GetMessagesParameterModel>()))
                .Callback<GetMessagesParameterModel>(argument => _actualArgument = argument)
                .Returns(Observable.Return(_expectedResult));
        }
    }
}
