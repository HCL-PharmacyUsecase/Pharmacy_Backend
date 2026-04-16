using System.Threading.Tasks;

namespace Pharmacy.API.Services
{
    public class EmailService : IEmailService
    {
        public Task SendOrderConfirmationEmail(string userEmail, string orderId)
        {
            // Integration with SendGrid/MailKit goes here
            return Task.CompletedTask;
        }
    }

    public interface IEmailService
    {
        Task SendOrderConfirmationEmail(string userEmail, string orderId);
    }
}