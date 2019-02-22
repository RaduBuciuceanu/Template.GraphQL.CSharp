using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Template.Business.Commands.Logging;

namespace Template.Presentation.Middlewares
{
    [SuppressMessage("Microsoft.Performance", "CA1724", Justification = "It's a middleware used for logging.")]
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

        private static string GetBody(HttpContext context)
        {
            context.Request.EnableRewind();
            context.Request.Body.Position = 0;

            var reader = new StreamReader(context.Request.Body);
            return reader.ReadToEnd();
        }
    }
}
