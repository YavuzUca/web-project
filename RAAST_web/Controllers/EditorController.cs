using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using RAAST_web.Models;

namespace RAAST_web.Controllers
{
    public class EditorController : Controller
    {
        


        // GET: Editor
        public ActionResult AddArticle()
        {
            return View();
        }

        public ActionResult AddPost()
        {
            return View();
        }

       //Page to send an email to all subcribers
        [HttpPost]
        public ViewResult AddPost(RAAST_web.Models.MailModel _objModelMail)
        {
            List<string> emails = GetEmails();
            //sets up mailmessage to be sent

            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                foreach(string email in emails)
                {
                    mail.Bcc.Add(email);
                }
                
                mail.From = new MailAddress("newsletter.hr.raast@gmail.com");
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("newsletter.hr.raast@gmail.com", "cd9#M6Y3tnaS$p$R$tSP"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("AddPost", _objModelMail);
            }
            else
            {
                return View();
            }
        }

        //Gets all emails from database as a list of strings.
        public List<string> GetEmails()
        {
            Data data = new Data();
            List<Newsletter> newsletters = data.Newsletters.ToList();

            List<string> emails = new List<string>();

            foreach(Newsletter email in newsletters)
            {
                emails.Add(email.email);
            }

            return emails;

        }

        public ActionResult Verify()
        {
            return View("Success");
        }
        
    }
}
