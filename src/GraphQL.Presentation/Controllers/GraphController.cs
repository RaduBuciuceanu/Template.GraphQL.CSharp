using System;
using System.Threading.Tasks;
using GraphQL.Presentation.Dtos;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Controllers
{
    [Route("graphql")]
    public class GraphController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public GraphController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQuery query)
        {
            ExecutionResult result = await Execute(query);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors?.Join(Environment.NewLine));
            }

            return Ok(result);
        }

        private async Task<ExecutionResult> Execute(GraphQuery query)
        {
            var schema = _serviceProvider.GetService<Schema>();
            var executor = new DocumentExecuter();

            return await executor.ExecuteAsync(options =>
            {
                options.Schema = schema;
                options.Query = query.Query;
                options.Inputs = query.Variables.ToInputs();
            });
        }
    }
}