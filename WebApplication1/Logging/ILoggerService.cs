namespace WebApplication1.Logging
{
    public interface ILoggerService
    {
        Task LogInformationAsync(string message);
        Task LogWarningAsync(string message);
        Task LogErrorAsync(Exception ex);
    }
}
