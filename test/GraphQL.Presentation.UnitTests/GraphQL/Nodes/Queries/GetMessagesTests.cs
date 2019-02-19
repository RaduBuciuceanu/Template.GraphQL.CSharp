using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using GraphQL.Business.Commands;
using GraphQL.Presentation.GraphQL.Types;
using GraphQL.Presentation.GraphQL.Types.Parameters;
using GraphQL.Presentation.UnitTests.GraphQL.Nodes.Base;
using GraphQL.Types;
using Moq;
using Moq.AutoMock;
using Shouldly;
using Xunit;
using GetMessages = GraphQL.Presentation.GraphQL.Nodes.Queries.GetMessages;
using GetMessagesParameterModel = GraphQL.Business.Models.Parameters.GetMessagesParameter;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Presentation.UnitTests.GraphQL.Nodes.Queries
{
    public class GetMessagesTests : HasArgumentTests<GetMessagesParameterModel, ResolveFieldContext>
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly IEnumerable<MessageModel> _expectedResult = new List<MessageModel>();
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
            _instance.Type.ShouldBe(typeof(Message));
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
            _instance.ArgumentType.ShouldBe(typeof(GetMessagesParameter));
        }

        [Fact]
        public async Task Resolve_InvokesCommand_WithRightId()
        {
            await (Task<IEnumerable<MessageModel>>)_instance.Resolve(Context);

            _actualArgument.Id.ShouldBe(ExpectedArgument.Id);
        }

        [Fact]
        public async Task Resolve_ReturnsResult_FromGetMessagesCommand()
        {
            var actual = await (Task<IEnumerable<MessageModel>>)_instance.Resolve(Context);

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
