using FirstMVC.Data;
using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }
        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

                    mailMessage.From = new System.Net.Mail.MailAddress("busra.ozdemir593@gmail.com", "Büşra Özdemir");
                    mailMessage.Subject = "İletişim Formu: " + model.FirstName + model.LastName;

                    mailMessage.To.Add("busra.ozdemir593@gmail.com");

                    string body;
                    body = "Ad Soyad: " + model.FirstName + model.LastName + "<br />";
                    body += "Telefon: " + model.Telephone + "<br />";
                    body += "E-posta: " + model.Email + "<br />";

                    body += "Mesaj: " + model.Message + "<br />";
                    body += "Tarih: " + DateTime.Now.ToString("dd MMMM yyyy HH:mm") + "<br />";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = body;

                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new System.Net.NetworkCredential("busra.ozdemir593@gmail.com", "");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                    ViewBag.Text = "Mesajınız gönderildi. Teşekkür ederiz.";
                } catch (Exception ex)
                {
                    ViewBag.Error = "Form gönderimi başarısız oldu. Lütfen daha sonra tekrar deneyiniz.";
                }
            }
            return View(model);
        }
        public ActionResult Project()
        {
            using(var db=new ApplicationDbContext())
            {
                var projects = db.Projects.ToList();
                return View(projects);
            }
            
        }
        public ActionResult Kvkk()
        {


            return View();
        }
        public ActionResult PrivacyPolicy()
        {


            return View();
        }
    }
}