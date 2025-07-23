using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShop.WebUI.Models;


namespace MultiShop.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(MailRequestViewModel model)
        {
            //Kimin gönderiği
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("MultiShop", "test-9a3z9awg9@srv1.mail-tester.com");

            mimeMessage.From.Add(mailboxAddressFrom);

            //kime gönderiyor
            MailboxAddress mailboxAddressTo = new MailboxAddress("Receiver", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.MessageContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("mail.srv1.mail-tester.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate("test-9a3z9awg9@srv1.mail-tester.com", "9a3z9awg9");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
