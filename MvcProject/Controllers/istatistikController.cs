using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class istatistikController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
       

        public ActionResult Index()
        {
            var categoryCount = categoryManager.CategoryCount();
            return View(categoryCount);
        }
        
    }
}