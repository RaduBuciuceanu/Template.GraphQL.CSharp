using System.Reactive.Linq;
using System.Threading.Tasks;
using GraphQL.Business.Commands.Messages;
using GraphQL.Presentation.GraphQL.Nodes.Types;
using GraphQL.Presentation.GraphQL.Types;
using GraphQL.Presentation.GraphQL.Types.Inputs;
using GraphQL.Presentation.UnitTests.GraphQL.Nodes.Base;
using GraphQL.Types;
using Moq;
using Moq.AutoMock;
using Shouldly;
using Xunit;
using CreateMessage = GraphQL.Presentation.GraphQL.Nodes.Mutations.CreateMessage;
using MessageInputModel = GraphQL.Business.Models.Inputs.MessageInput;
using MessageModel = GraphQL.Business.Models.Message;

namespace GraphQL.Presentation.UnitTests.GraphQL.Nodes.Mutations
{
    public class CreateMessageTests : HasArgumentTests<MessageInputModel, ResolveFieldContext>
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly MessageModel _expectedResult = new MessageModel();
        private readonly IMutation _instance;

        private MessageInputModel _actualArgument;

        public CreateMessageTests() : base("input", Arguments.MessageInput)
        {
            SetupCommand();
            _instance = _mocker.CreateInstance<CreateMessage>();
        }

        [Fact]
        public void Constructor_Type_IsSet()
        {
            _instance.Type.ShouldBe(typeof(Message));
        }

        [Fact]
        public void Constructor_Name_IsSet()
        {
            _instance.Name.ShouldBe("createMessage");
        }

        [Fact]
        public void Constructor_Description_IsSet()
        {
            _instance.Description.ShouldBe("Creates a message and returns the created one.");
        }

        [Fact]
        public void Constructor_ArgumentName_IsSet()
        {
            _instance.ArgumentName.ShouldBe("input");
        }

        [Fact]
        public void Constructor_ArgumentDescription_IsSet()
        {
            _instance.ArgumentDescription.ShouldBe("The message to be created.");
        }

        [Fact]
        public void Constructor_ArgumentType_IsSet()
        {
            _instance.ArgumentType.ShouldBe(typeof(MessageInput));
        }

        [Fact]
        public async Task Resolve_InvokesCommand_WithRightAuthor()
        {
            await (Task)_instance.Resolve(Context);

            _actualArgument.Author.ShouldBe(ExpectedArgument.Author);
        }

        [Fact]
        public async Task Resolve_InvokesCommand_WithRightContent()
        {
            await (Task)_instance.Resolve(Context);

            _actualArgument.Content.ShouldBe(ExpectedArgument.Content);
        }

        [Fact]
        public async Task Resolve_ReturnsResult_FromCommand()
        {
            var actual = await (Task<MessageModel>)_instance.Resolve(Context);

            actual.ShouldBe(_expectedResult);
        }

        private void SetupCommand()
        {
            _mocker.GetMock<ICreateMessage>()
                .Setup(command => command.Execute(It.IsAny<MessageInputModel>()))
                .Callback<MessageInputModel>(input => _actualArgument = input)
                .Returns(Observable.Return(_expectedResult));
        }
    }
}
