using System.Threading.Tasks;

namespace NXS.Services.Abstract
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}