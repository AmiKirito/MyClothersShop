using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using MyClothersShop.ViewModels;
using static MyClothersShop.Models.Enum;
using MyClothersShop.Models;

namespace MyClothersShop.Controllers
{
    public class ContactUsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendEmailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var mailbody = $@"
            Hello website owner,
            
            This is a new contact request from your website:
            
            Name: {model.Name}
            Email: {model.Email}
            Message: ""{model.Message}""
            
            Cheers,
            
            The websites contact form";
            SendEmail(model, mailbody);
            return View();
        }
        public void SendEmail(SendEmailViewModel sendEmail, string mess)
        {
            try
            {
                var credentials = new NetworkCredential("romankrol2000@gmail.com", "p3hgs8765jgfh2000");

                var mailToOrigin = new MailMessage()
                {
                    From = new MailAddress("mirinakot@gmail.com", sendEmail.Name),
                    Subject = "My Clothers Shop",
                    Body = mess
                };

                var mailToSender = new MailMessage()
                {
                    From = new MailAddress("noreply@myclothersshop.com", "Conact form response"),
                    Subject = "Order placement",
                    Body = @"
                            Dear cient!

                            We are glad to let you know that we successfully received your email! 
                            You will receive a reply as soon as the website owner checks the inbox.

                            Regards,
                            My Clothers Shop Bot

                            Contacts: 
                            Email - romankrol2000@gmail.com
                            Phone - +380993285448 - Roman

                            MyClothersShop LTD.
                            "
                };

                mailToOrigin.IsBodyHtml = false;
                mailToOrigin.Body.Replace(Environment.NewLine, "<br />").ToString();
                mailToOrigin.To.Add(new MailAddress("romankrol2000@gmail.com"));

                mailToSender.IsBodyHtml = false;
                mailToSender.Body.Replace(Environment.NewLine, "<br />").ToString();
                mailToSender.To.Add(new MailAddress(sendEmail.Email));

                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                client.Send(mailToOrigin);
                client.Send(mailToSender);
                Alert(NotificationType.success);
            }
            catch (Exception e)
            {
                Alert(NotificationType.error);
            }
        }
        public void Alert(NotificationType notificationType)
        {
            var msg = notificationType;
            TempData["sendRes"] = msg;
        }
        
    }
}
