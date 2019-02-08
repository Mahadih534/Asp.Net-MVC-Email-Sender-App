using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TestApp.Controllers
{
    public class SubscribeController : Controller
    {
        // GET: Subscribe
       

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public  async Task<ActionResult> Contact(Contact contact)
        {

            MailMessage mailMessage = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            mailMessage.From = new MailAddress("senderMailAddress");
            mailMessage.To.Add(contact.Email);
            mailMessage.Subject = "Test Email";
            mailMessage.Body = "<h1 style='text-align: center; color: blue;'> The User has been Successfully Subscribed  </h1> <h4>Hello "+contact.FirstName+" "+contact.LastName+" thank you to subscribe our website </h4>";
            mailMessage.IsBodyHtml = true;

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("senderMailAddress","SenderPassword");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
          await  smtp.SendMailAsync(mailMessage);


            return View();
        }



    }
}