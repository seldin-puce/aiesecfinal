using System.Net.Mail;
using System.Threading.Tasks;
using MailMessage = Aiesec.ExternalServices.Model.MailMessage;

namespace Aiesec.ExternalServices.Mail
{
    public interface IMailService
    {
        Task SendMailAsync(MailMessage message);
    }
}