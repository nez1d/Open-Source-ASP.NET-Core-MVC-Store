using MailKit.Net.Smtp;
using MimeKit;

namespace ShopDevelop.Identity.DuendeServer.Service;

public class EmailService
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        string emailFrom = "nezidnezid6@gmail.com";
        string password = "gsht bfbj bvrm zujt";
        
        var emailToSend = new MimeMessage();
        emailToSend.From.Add(MailboxAddress.Parse(emailFrom));
        emailToSend.To.Add(MailboxAddress.Parse(email));
        emailToSend.Subject = subject;
        emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = message
        };
        
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.gmail.com", 465, true);
            client.Authenticate(email, password);
            await client.SendAsync(emailToSend);

            await client.DisconnectAsync(true);
        }
    }
}