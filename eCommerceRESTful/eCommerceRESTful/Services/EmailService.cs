using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Options;

namespace eCommerceRESTful.Services;

public class EmailService
{
    // Email service sends emails. Like a post office.
    
    private readonly EmailSettings _emailSettings; //the address of the email server and the credentials (like the postman's ID)
    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
    
    // Method to send emails. It is like a postman delivering a letter.
    public void SendEmail(string toEmail, string subject, string body) //kind of like the letter itself.
    {
        var message = new MimeMessage(); //the letter (or envelope)
        message.From.Add(new MailboxAddress("Support CareApp", _emailSettings.SmtpUsername)); //the sender
        message.To.Add(new MailboxAddress("Reciever Name", toEmail)); //the reciever
        message.Subject = subject;
        var textPart = new TextPart("plain")
        {
            Text = body
        };
        message.Body = textPart;
        using (var client = new SmtpClient()) //the post office. Smtp (Simple Mail Transfer Protocol) is the rules used to send emails.
        {
            client.Connect(_emailSettings.SmtpServer, _emailSettings.SmtpPort,
                SecureSocketOptions.StartTls);
            client.Authenticate(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}