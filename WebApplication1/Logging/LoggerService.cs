using System;
using System.Diagnostics.Eventing.Reader;

using WebApplication1.Entity;
using WebApplication1.Enums;
using WebApplication1.Repositary;

namespace WebApplication1.Logging
{
    public class LoggerService : ILoggerService
    {
        private readonly IRepositary<Log> _repository;

        public LoggerService(IRepositary<Log> repository)
        {
            _repository = repository;
        }
        public async Task LogErrorAsync(Exception ex)
        {
            string message = ex.Message;
            await _repository.AddAsync(CreateLog(message, LogType.Error)).ConfigureAwait(false);
            await _repository.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task LogInformationAsync(string message)
        {
            await _repository.AddAsync(CreateLog(message, LogType.Info)).ConfigureAwait(false);
            await _repository.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task LogWarningAsync(string message)
        {
            await _repository.AddAsync(CreateLog(message, LogType.Warn)).ConfigureAwait(false);
            await _repository.SaveChangesAsync().ConfigureAwait(false);
        }

        public static Log CreateLog(string message, LogType type)
        {
            return new Log
            {
                Message = message,
                LogLevel = type.ToString(),
                Timestamp = DateTime.Now,
            };
        }
    }
}
