using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;
using MailKit.Security;
using EmailMethod.DTOs;

namespace EmailMethod;
public class EmailService : IEmailService
{ 

    public void Send(EmailDto request, string username, string password)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(username));
        email.To.Add(MailboxAddress.Parse(request.Recipient));
        email.Subject = "Test Email Subject";
        email.Body = new TextPart(TextFormat.Text) { Text = request.Body };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(username, password);
        smtp.Send(email);
        smtp.Disconnect(true);
        return;
    }

}

