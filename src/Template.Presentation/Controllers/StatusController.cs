using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Microsoft.AspNetCore.Mvc;
using Template.Business.Commands.Status;
using Template.Business.Models;

namespace Template.Presentation.Controllers
{
    [Route("status")]
    public class StatusController : Controller
    {
        private readonly IGetApplicationVersion _getApplicationVersion;
        private readonly IGetApplicationHealth _getApplicationHealth;

        public StatusController(IGetApplicationVersion getApplicationVersion, IGetApplicationHealth getApplicationHealth)
        {
            _getApplicationVersion = getApplicationVersion;
            _getApplicationHealth = getApplicationHealth;
        }

        [HttpGet("version")]
        public ApplicationVersion GetVersion()
        {
            return _getApplicationVersion.Execute(Unit.Default).Wait();
        }

        [HttpGet("health")]
        public IEnumerable<ComponentHealth> GetHealth()
        {
            return _getApplicationHealth.Execute(Unit.Default).Wait();
        }
    }
}
