using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Moq;
using Shouldly;
using Template.Business.Commands.Status;
using Template.Business.Models;
using Xunit;

namespace Template.Business.UnitTests.Commands.Status
{
    public class GetApplicationHealthTests
    {
        private readonly IEnumerable<Mock<IGetComponentHealth>> _commands;
        private readonly IGetApplicationHealth _instance;

        public GetApplicationHealthTests()
        {
            _commands = BuildCommands();
            _instance = new GetApplicationHealth(_commands.Select(mock => mock.Object));
        }

        [Fact]
        public void Execute_InvokesExecute_FromEachCommand()
        {
            _instance.Execute().Wait();

            foreach (Mock<IGetComponentHealth> command in _commands)
            {
                command.Verify(instance => instance.Execute(default(Unit)), Times.Once());
            }
        }

        [Fact]
        public void Execute_ReturnsCollectedResults_FromEachCommand()
        {
            IEnumerable<ComponentHealth> actual = _instance.Execute().Wait().ToList();

            foreach (Mock<IGetComponentHealth> command in _commands)
            {
                actual.ShouldContain(command.Object.Execute(Unit.Default).Wait());
            }
        }

        private static IEnumerable<Mock<IGetComponentHealth>> BuildCommands()
        {
            var mocks = new List<Mock<IGetComponentHealth>>
            {
                BuildCommand(new ComponentHealth()),
                BuildCommand(new ComponentHealth())
            };

            return mocks;
        }

        private static Mock<IGetComponentHealth> BuildCommand(ComponentHealth result)
        {
            var mock = new Mock<IGetComponentHealth>();

            mock
                .Setup(instance => instance.Execute(Unit.Default))
                .Returns(Observable.Return(result));

            return mock;
        }
    }
}
