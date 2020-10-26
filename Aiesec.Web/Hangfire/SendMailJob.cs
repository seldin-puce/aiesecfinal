using Aiesec.ExternalServices.Mail;
using Aiesec.ExternalServices.Model;
using Aiesec.Web.Options;
using Google.Apis.Auth.OAuth2;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Aiesec.Web.Hangfire
{
    public class SendMailJob : ISendMailJob
    {
        private EmailServerNoReplyOptions _serverNoReplyOptions;
        private IMailService _mailService;
        public SendMailJob(EmailServerNoReplyOptions ServerNoReplyOptions,
             IMailService mailService)
        {
            _serverNoReplyOptions = ServerNoReplyOptions;
            _mailService = mailService;
        }

        public async Task SendEmail()
        {
            await _mailService.SendMailAsync(new MailMessage
            {
                Body = "Ovo je tijelo mejla",
                Subject = "Neki naslov",
                To = "puceseldin@gmail.com",
                MailServer = new MailServer(_serverNoReplyOptions)
            });








        }
    }
}
