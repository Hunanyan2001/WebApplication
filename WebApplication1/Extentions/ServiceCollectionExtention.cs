using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebApplication1.Controllers;
using WebApplication1.DBContexts;
using WebApplication1.Entity;
using WebApplication1.Logging;
using WebApplication1.Managers;
using WebApplication1.Middleware;
using WebApplication1.Repositary;

namespace WebApplication1.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositary<>), typeof(Repositary<>));
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<UserController>();
        }

        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
        }

        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandler>();
        }
    }
}
