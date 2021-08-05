using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminUser = c.Admins.FirstOrDefault(x => x.AdminUsername == p.AdminUsername && x.AdminPassword == p.AdminPassword);
            if (adminUser != null)
            {
                FormsAuthentication.SetAuthCookie(adminUser.AdminUsername, false);
                Session["AdminUsername"] = adminUser.AdminUsername;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writerUser = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            var writerUser = writerLoginManager.GetWriter(p.WriterMail, p.WriterPassword);
            if (writerUser != null)
            {
                FormsAuthentication.SetAuthCookie(writerUser.WriterMail, false);
                Session["WriterMail"] = writerUser.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}