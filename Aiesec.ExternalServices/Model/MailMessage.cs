using Aiesec.Web.Options;

namespace Aiesec.ExternalServices.Model
{
    public class MailMessage
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public MailServer MailServer { get; set; }
    }

    public class MailServer
    {
        public string Domain { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public MailServer(EmailServerNoReplyOptions emailServerNoReplyOptions)
        {
            Email = emailServerNoReplyOptions.Email;
            Name = emailServerNoReplyOptions.Name;
            Port = emailServerNoReplyOptions.Port;
            Username = emailServerNoReplyOptions.Username;
            Password = emailServerNoReplyOptions.Password;
            Domain = emailServerNoReplyOptions.Domain;
        }
    }
}