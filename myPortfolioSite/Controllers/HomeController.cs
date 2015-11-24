using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using myPortfolioSite.Models;

namespace myPortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        // All entries must be lowercase, because we use .ToLower on the challenge string.
        List<string> whitelist = new List<string> {
            /* "about", */
            "contact",
            "knowledge",
            "skillset",
            "work",
            "education",
            "index",
            "projects",
            "contactsuccess",
        };

        [HttpGet]
        public ActionResult StaticView(string viewName)
        {
            string viewNameRequest = "Index";
            viewName = viewName.ToLower();

            if (whitelist.Contains(viewName))
                viewNameRequest = viewName;

            return View(viewNameRequest);
        }

        /* Contact form implementation ripped from:
        http://www.mikesdotnetting.com/article/268/how-to-send-email-in-asp-net-mvc
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactEmailForm model)
        {
            if (ModelState.IsValid)
            {
                string body = "Email From: {0} ({1}) Message: {2}";
                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress("email@gmail.com"));
                message.From = new MailAddress("email@gmail.com");
                message.Subject = "Site contact form test";
                // So this is quite cool; gotta remember this method...
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient())
                {
                    NetworkCredential credential = new NetworkCredential
                    {
                        UserName = "email@email.com",
                        Password = "password" // TODO: use SecurePassword instead of Password.
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 567;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("StaticView", "ContactSuccess");
                }
            }
            // Notice, this return is for when modelstate.isvalid returns false.
            return View("Contact", model);
        }
    }
}
 