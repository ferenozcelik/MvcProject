using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var values = contentManager.GetList(p);
            if (string.IsNullOrEmpty(p))
            {
                values = contentManager.GetList();
            }
            return View(values.ToList());
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListByHeadingID(id);
            return View(contentValues);
        }
    }
}