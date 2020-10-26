﻿using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System.Threading;
using System.Threading.Tasks;
using Aiesec.ExternalServices.Model;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;
using Google.Apis.Util;
using MailKit.Security;

namespace Aiesec.ExternalServices.Mail
{
    public class MailService : IMailService
    {
        public async Task SendMailAsync(MailMessage message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(message.MailServer.Name, message.MailServer.Email));
            mimeMessage.To.Add(new MailboxAddress(message.To));
            mimeMessage.Subject = message.Subject;
            mimeMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = message.Body
            };
            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                //client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(message.MailServer.Domain, message.MailServer.Port, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                client.Authenticate(message.MailServer.Username, message.MailServer.Password, CancellationToken.None);
                client.Send(mimeMessage);
                client.Disconnect(true);
            }
        }
    }
}