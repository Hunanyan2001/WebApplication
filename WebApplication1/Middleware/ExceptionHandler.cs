namespace WebApplication1.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
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

            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Excpetiona qce ynger jan hyly tes incha asum");
        }
    }
}
