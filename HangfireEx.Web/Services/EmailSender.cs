using SendGrid;
using SendGrid.Helpers.Mail;

namespace HangfireExample.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {
            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("sss@gmail.com","Exampleuser");
            var subject = "deneme gönderim";
            var to = new EmailAddress("ee@gmail.com", "alıcı");
          //  var plaintextcontent = "aaaaa";
            var htmlContent = $"SiteKuralları{message}";
            var msg = MailHelper.CreateSingleEmail(from,to,subject,null,htmlContent);
            var response= await client.SendEmailAsync(msg);

        }
    }
}
