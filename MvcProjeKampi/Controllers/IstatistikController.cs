using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());    
        public ActionResult Index()
        {
            var categories = cm.GetList().Count();
            var catergoriWithName = cm.GetCategoryWithName("Yazılım");
            var headersSoftwareCount = hm.GetListByCategoryId(catergoriWithName.CategoryID).Count();
            var includeCharValueCount = wm.includeCharCount("a");
            var difranceCategoryStatus = cm.CategoryStatusDiffrance();

            



            return View();
        }
    }
}