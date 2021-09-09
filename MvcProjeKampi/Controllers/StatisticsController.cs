using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal()); 
        Context context = new Context();
        public ActionResult Statistics()
        {

            var catergoriWithName = cm.GetCategoryWithName("Yazılım");

            var categoryCount = context.Categories.Count().ToString();
            var categoryCaountForSoftware = context.Headings.Count(x => x.CategoryID == catergoriWithName.CategoryID).ToString();
            var writersIncludeChar = context.Writers.Count(x => x.WriterName.Contains("a")).ToString();
            var categoryCountWithMostTitles = context.Categories.Where(c => c.CategoryID == context.Headings.GroupBy(x => x.CategoryID)
            .OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            var categoryStatusDiffrance = Math.Abs( context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false));

            ViewBag.categoryCount = categoryCount;
            ViewBag.categoryCaountForSoftware = categoryCaountForSoftware;
            ViewBag.writersIncludeChar = writersIncludeChar;
            ViewBag.categoryCountWithMostTitles = categoryCountWithMostTitles;
            ViewBag.categoryStatusDiffrance = categoryStatusDiffrance;


            return View();
        }
    }
}