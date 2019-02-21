using System;
using System.Diagnostics;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Tasks;
using GraphQL.Business.Commands.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace GraphQL.Presentation.Middlewares
{
    public class Logging
    {
        private readonly RequestDelegate _next;
        private readonly Stopwatch _watch;

        public Logging(RequestDelegate next)
        {
            _next = next;
            _watch = new Stopwatch();
        }

        public async Task Invoke(HttpContext context, ILogger logger)
        {
            _watch.Restart();

            try
            {
                await _next(context);
                logger.Info(BuildInfoMessage(context)).Wait();
            }
            catch (Exception exception)
            {
                logger.Error(BuildErrorMessage(context), exception).Wait();
                throw;
            }
        }

        private string BuildInfoMessage(HttpContext context)
        {
            return $"{context.Request.Method}: {context.Request.Path} took: {_watch.Elapsed.TotalMilliseconds} ms." +
                   $"Body: {GetBody(context)}";
        }

        private string BuildErrorMessage(HttpContext context)
        {
            return $"{context.Request.Method}:: {context.Request.Path} took: {_watch.Elapsed.TotalMilliseconds} ms." +
                   $"Body: {GetBody(context)}";
        }

        private string GetBody(HttpContext context)
        {
            context.Request.EnableRewind();
            context.Request.Body.Position = 0;

            var reader = new StreamReader(context.Request.Body);
            return reader.ReadToEnd();
        }
    }
}
