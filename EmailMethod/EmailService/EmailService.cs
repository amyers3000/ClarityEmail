using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;
using MailKit.Security;
using EmailMethod.DTOs;

namespace EmailMethod;
public class EmailService : IEmailService
{

    public async Task<ServiceResponse<EmailDto>> Send(EmailDto request, string username, string password)
    {
        var response = new ServiceResponse<EmailDto>();
        try
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(username));
            email.To.Add(MailboxAddress.Parse(request.Recipient));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Text) { Text = request.Body };
            for (int i = 0; i <= 3; i++)
            {
                try
                {
                    using var smtp = new SmtpClient();
                    await smtp.ConnectAsync("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync(username, password);
                    await smtp.SendAsync(email);

                    response.Success = true;
                    response.Data = request;
                    response.Message = "Message Sent";

                    return response;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }
        }
        catch(Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
       
    }

}

