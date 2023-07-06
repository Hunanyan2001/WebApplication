using WebApplication1.Logging;

namespace WebApplication1.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public ExceptionHandler(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext contex)
        {
            try
            {
                await _next(contex);   
            }
            catch (Exception ex)
            {
                await Handle(contex, ex);
            }
        }

        private async Task Handle(HttpContext context, Exception ex)
        {
            try
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Excpetiona qce ynger jan hyly tes incha asum");

                using var scope = _serviceProvider.CreateScope();
                var logger = scope.ServiceProvider.GetRequiredService<ILoggerService>();

                await logger.LogErrorAsync(ex);
            }
            catch
            {

            }
        }
    }
}
