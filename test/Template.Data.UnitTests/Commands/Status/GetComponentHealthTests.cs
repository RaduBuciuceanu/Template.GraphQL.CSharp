using System;
using System.Reactive;
using System.Reactive.Linq;
using Moq;
using Shouldly;
using Template.Business.Commands.Status;
using Template.Business.Models;
using Template.Data.Commands.Status;
using Template.Data.Repositories;
using Xunit;

namespace Template.Data.UnitTests.Commands.Status
{
    public class GetComponentHealthTests
    {
        private const string Name = "Data layer health";
        private const string SuccessMessage = "Data layer health check succeeded.";
        private const string FailMessage = "Data layer health check failed.";

        private readonly IGetComponentHealth _instance;
        private readonly IGetComponentHealth _failInstance;
        private readonly Mock<IStatusRepository> _repository;

        public GetComponentHealthTests()
        {
            _repository = BuildRepository();
            _instance = new GetComponentHealth(_repository.Object);
            _failInstance = new GetComponentHealth(BuildFailRepository());
        }

        [Fact]
        public void Execute_InvokesPing_FromRepository()
        {
            _instance.Execute(Unit.Default).Wait();

            _repository.Verify(instance => instance.Ping());
        }

        [Fact]
        public void Execute_ResultHasRightName_WhenCommandSucceeded()
        {
            ComponentHealth actual = _instance.Execute(Unit.Default).Wait();

            actual.Name.ShouldBe(Name);
        }

        [Fact]
        public void Execute_ResultHasRightName_WhenCommandFailed()
        {
            ComponentHealth actual = _failInstance.Execute(Unit.Default).Wait();

            actual.Name.ShouldBe(Name);
        }

        [Fact]
        public void Execute_ResultHasRightMessage_WhenCommandSucceeded()
        {
            ComponentHealth actual = _instance.Execute(Unit.Default).Wait();

            actual.Message.ShouldBe(SuccessMessage);
        }

        [Fact]
        public void Execute_ResultHasRightMessage_WhenCommandFailed()
        {
            ComponentHealth actual = _failInstance.Execute(Unit.Default).Wait();

            actual.Message.ShouldStartWith(FailMessage);
        }

        [Fact]
        public void Execute_ResultHasRightPassed_WhenCommandSucceeded()
        {
            ComponentHealth actual = _instance.Execute(Unit.Default).Wait();

            actual.Passed.ShouldBeTrue();
        }

        [Fact]
        public void Execute_ResultHasRightPassed_WhenCommandFailed()
        {
            ComponentHealth actual = _failInstance.Execute(Unit.Default).Wait();

            actual.Passed.ShouldBeFalse();
        }

        [Fact]
        public void Execute_ResultHasRightDuration_WhenCommandSucceeded()
        {
            ComponentHealth actual = _instance.Execute(Unit.Default).Wait();

            actual.Duration.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void Execute_ResultHasRightDuration_WhenCommandFailed()
        {
            ComponentHealth actual = _failInstance.Execute(Unit.Default).Wait();

            actual.Duration.ShouldNotBeNullOrEmpty();
        }

        private static Mock<IStatusRepository> BuildRepository()
        {
            var mock = new Mock<IStatusRepository>();

            mock
                .Setup(instance => instance.Ping())
                .Returns(Observable.Return(Unit.Default));

            return mock;
        }

        private static IStatusRepository BuildFailRepository()
        {
            var mock = new Mock<IStatusRepository>();

            mock
                .Setup(instance => instance.Ping())
                .Returns(Observable.Throw<Unit>(new Exception()));

            return mock.Object;
        }
    }
}
