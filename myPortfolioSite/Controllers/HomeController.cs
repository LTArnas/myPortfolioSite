using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
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
        public ActionResult Contact(ContactEmailForm model)
        {
            if (ModelState.IsValid)
            {
                // GetSection is case sensitive.
                SmtpSection smtpConfig = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                
                string body = "<h1>Email From:</h1> <p>{0} ({1})</p> <h2>Message:</h2> <p>{2}</p>";
                MailMessage message = new MailMessage();
                // TODO: try-catch for MailAddress construction (for null, for example)
                message.To.Add(new MailAddress(smtpConfig.From));
                message.From = new MailAddress(smtpConfig.From);
                message.Subject = "Contact Form";
                // So this is quite cool; gotta remember this method...
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                message.BodyEncoding = System.Text.Encoding.UTF8;

                using (SmtpClient smtp = new SmtpClient())
                {
                    // TODO: try-catch sending
                    // TODO: It'd be nice if we do the sending async...
                    smtp.Send(message);
                    return RedirectToAction("StaticView", routeValues:"ContactSuccess");
                }
            }
            // Notice, this return is for when modelstate.isvalid returns false.
            return View("Contact", model);
        }
    }
}
 