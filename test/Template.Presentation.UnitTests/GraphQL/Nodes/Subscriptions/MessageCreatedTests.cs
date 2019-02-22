using System.Reactive.Linq;
using GraphQL.Subscription;
using GraphQL.Types;
using Moq;
using Moq.AutoMock;
using Shouldly;
using Template.Business.Commands.Messages;
using Template.Business.Models.Parameters;
using Template.Presentation.GraphQL.Types;
using Template.Presentation.UnitTests.GraphQL.Nodes.Base;
using Xunit;
using MessageCreated = Template.Presentation.GraphQL.Nodes.Subscriptions.MessageCreated;
using MessageCreatedParameterModel = Template.Business.Models.Parameters.MessageCreatedParameter;
using MessageModel = Template.Business.Models.Message;

namespace Template.Presentation.UnitTests.GraphQL.Nodes.Subscriptions
{
    public class MessageCreatedTests : HasArgumentTests<MessageCreatedParameter, ResolveEventStreamContext>
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly MessageModel _expectedResult = new MessageModel();
        private readonly MessageCreated _instance;

        private MessageCreatedParameterModel _actualArgument;

        public MessageCreatedTests() : base("parameter", Arguments.MessageCreatedParameter)
        {
            SetupCommand();
            _instance = _mocker.CreateInstance<MessageCreated>();
        }

        [Fact]
        public void Constructor_Name_IsSet()
        {
            _instance.Name.ShouldBe("messageCreated");
        }

        [Fact]
        public void Constructor_Description_IsSet()
        {
            _instance.Description.ShouldBe("Returns the created event when any is created.");
        }

        [Fact]
        public void Constructor_Type_IsSet()
        {
            _instance.Type.ShouldBe(typeof(Message));
        }

        [Fact]
        public void Constructor_ArgumentName_IsSet()
        {
            _instance.ArgumentName.ShouldBe("parameter");
        }

        [Fact]
        public void Constructor_ArgumentDescription_IsSet()
        {
            _instance.ArgumentDescription.ShouldBe("The parameter used to filter messages.");
        }

        [Fact]
        public void Constructor_ArgumentType_IsSet()
        {
            _instance.ArgumentType.ShouldBe(typeof(Presentation.GraphQL.Types.Parameters.MessageCreatedParameter));
        }

        [Fact]
        public void Resolve_ReturnsSource_FromContext()
        {
            var context = new ResolveFieldContext { Source = new MessageModel() };

            object actual = _instance.Resolve(context);

            actual.ShouldBe(context.Source);
        }

        [Fact]
        public void Subscribe_InvokesCommand_WithRightAuthor()
        {
            _instance.Subscribe(Context).Wait();

            _actualArgument.Author.ShouldBe(ExpectedArgument.Author);
        }

        [Fact]
        public void Subscribe_ReturnsResult_FromCommand()
        {
            object actual = _instance.Subscribe(new ResolveEventStreamContext()).Wait();

            actual.ShouldBe(_expectedResult);
        }

        private void SetupCommand()
        {
            _mocker.GetMock<IMessageCreated>()
                .Setup(command => command.Execute(It.IsAny<MessageCreatedParameterModel>()))
                .Callback<MessageCreatedParameterModel>(argument => _actualArgument = argument)
                .Returns(Observable.Return(_expectedResult));
        }
    }
}
