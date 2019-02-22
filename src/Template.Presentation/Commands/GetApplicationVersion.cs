using System;
using System.Diagnostics;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Template.Business.Commands.Status;
using Template.Business.Models;

namespace Template.Presentation.Commands
{
    public class GetApplicationVersion : IGetApplicationVersion
    {
        private const string UtcSuffix = "(UTC)";

        private readonly IHostingEnvironment _environment;

        public GetApplicationVersion(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IObservable<ApplicationVersion> Execute(Unit input = default(Unit))
        {
            return Observable.Return(BuildVersion());
        }

        private ApplicationVersion BuildVersion()
        {
            return new ApplicationVersion
            {
                AssemblyName = _environment.ApplicationName,
                AssemblyVersion = GetVersion(),
                Environment = _environment.EnvironmentName,
                DeployedAt = GetDeployedAt(),
                StartedAt = GetStartedAt(),
            };
        }

        private string GetVersion()
        {
            Assembly assembly = GetType().Assembly;
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return versionInfo.FileVersion;
        }

        private string GetDeployedAt()
        {
            Assembly assembly = GetType().Assembly;
            return $"{File.GetLastWriteTimeUtc(assembly.Location):f} {UtcSuffix}";
        }

        private static string GetStartedAt()
        {
            return $"{Program.StartedAt:f} {UtcSuffix}";
        }
    }
}
