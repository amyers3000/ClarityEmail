using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;
using MailKit.Security;
using EmailMethod.DTOs;

namespace EmailMethod;
public class EmailService : IEmailService
{

    public async Task<bool> Send(EmailDto request, string username, string password)
    {
        try
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(username));
            email.To.Add(MailboxAddress.Parse(request.Recipient));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Text) { Text = request.Body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(username, password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

}

