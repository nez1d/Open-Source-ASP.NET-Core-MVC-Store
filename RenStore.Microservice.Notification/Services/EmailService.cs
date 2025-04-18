using MailKit.Net.Smtp;
using MimeKit;

namespace RenStore.Microservice.Notification.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration configuration;
    private readonly ILogger<EmailService> logger;
    
    public EmailService(
        IConfiguration configuration,
        ILogger<EmailService> logger)
    { 
        this.configuration = configuration;
        this.logger = logger;
    }
    
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        logger.LogInformation($"Sending email to {email} with subject {subject}.");
        
        var emailToSend = new MimeMessage();
        emailToSend.From.Add(MailboxAddress.Parse(email));
        emailToSend.To.Add(MailboxAddress.Parse(email));
        emailToSend.Subject = subject;
        emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = message
        };
        
        try
        {
            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 465, true);
            await client.AuthenticateAsync(
                userName: configuration["EmailFrom"], 
                password: configuration["EmailPassword"]);
            await client.SendAsync(emailToSend);
            await client.DisconnectAsync(true);
        }
        catch (SmtpCommandException ex)
        {
            logger.LogError(ex, ex.Message);
            Console.WriteLine($"SMTP Error: {ex.StatusCode} - {ex.Message}");
        }
        
        logger.LogInformation($"Sent email to {email} with subject {subject}.");
    }
}