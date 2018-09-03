using Microsoft.Extensions.Logging;

namespace Asp.AngularCore.git.Services
{
    public class NullEmail : IMailService
    {
        private readonly ILogger<NullEmail> _logger;

        public NullEmail(ILogger<NullEmail> logger)
        {
            _logger = logger;
        }
        public void Message(string to, string subject, string body)
        {
            _logger.LogInformation($"To:{to}  Subject:{subject}   Body:{body}");
        }
    }
}
