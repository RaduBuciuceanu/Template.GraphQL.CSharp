using System.Diagnostics;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Moq.AutoMock;
using Shouldly;
using Template.Business.Commands.Status;
using Template.Business.Models;
using Template.Presentation.Commands;
using Xunit;

namespace Template.Presentation.UnitTests.Commands
{
    public class GetApplicationVersionTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly IGetApplicationVersion _instance;

        public GetApplicationVersionTests()
        {
            SetupHostingEnvironment();
            _instance = _mocker.CreateInstance<GetApplicationVersion>();
        }

        [Fact]
        public void Execute_AssemblyName_IsNameReturnedByHostingEnvironment()
        {
            ApplicationVersion actual = _instance.Execute(Unit.Default).Wait();

            actual.AssemblyName.ShouldBe(_mocker.Get<IHostingEnvironment>().ApplicationName);
        }

        [Fact]
        public void Execute_Version_IsPresentationAssemblyVersion()
        {
            ApplicationVersion actual = _instance.Execute(Unit.Default).Wait();

            actual.AssemblyVersion.ShouldBe(GetExpectedAssemblyVersion());
        }

        [Fact]
        public void Execute_Environment_IsEnvironmentReturnedByHostingEnvironment()
        {
            ApplicationVersion actual = _instance.Execute(Unit.Default).Wait();

            actual.Environment.ShouldBe(_mocker.Get<IHostingEnvironment>().EnvironmentName);
        }

        [Fact]
        public void Execute_DeployedAt_IsPresentationAssemblyCreatedTime()
        {
            ApplicationVersion actual = _instance.Execute(Unit.Default).Wait();

            actual.DeployedAt.ShouldBe(GetPresentationAssemblyCreatedDate());
        }

        [Fact]
        public void Execute_StartedAt_IsStartupStartedAt()
        {
            ApplicationVersion actual = _instance.Execute(Unit.Default).Wait();

            actual.StartedAt.ShouldBe(GetPresentationStartedAt());
        }

        private static string GetPresentationStartedAt()
        {
            return $"{Program.StartedAt:f} (UTC)";
        }

        private string GetExpectedAssemblyVersion()
        {
            Assembly assembly = _instance.GetType().Assembly;
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(assembly.Location);
            return version.FileVersion;
        }

        private string GetPresentationAssemblyCreatedDate()
        {
            Assembly assembly = _instance.GetType().Assembly;
            return $"{File.GetLastWriteTimeUtc(assembly.Location):f} (UTC)";
        }

        private void SetupHostingEnvironment()
        {
            _mocker.GetMock<IHostingEnvironment>()
                .Setup(instance => instance.EnvironmentName)
                .Returns("Random name here.");

            _mocker.GetMock<IHostingEnvironment>()
                .Setup(instance => instance.ApplicationName)
                .Returns("Random name here.");
        }
    }
}
