using MessageBoard.Data;
using MessageBoard.Models;
using MessageBoard.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private IMailService mail;
        private IMessageBoardRepository repo;

        public HomeController(IMailService mail, IMessageBoardRepository repo)
        {
            this.mail = mail;
            this.repo = repo;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var topics = repo.GetTopics()
                .OrderByDescending(o => o.Created)
                .Take(25)
                .ToList();

            return View(topics);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact Page";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment from :{1}{0}Email:{2}{0}Website:{2}{0}Comment:{3}{0}"
                , Environment.NewLine, model.Name, model.Email, model.Website, model.Comment);

            if (mail.SendMail("from@shahab.com", "contact@shahab.com", "Contact Us", msg))
            {
                ViewBag.MailSent = true;
            }
            return View();
        }

        public ActionResult MyMessages()
        {
            return View();
        }
    }
}
