using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoCompleteProject.Models;

namespace AutoCompleteProject.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            AutoCompleteEntities1 db = new AutoCompleteEntities1();


            var data = db.tblStudents.ToList();
            return View(data);
        }



        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            AutoCompleteEntities1 db = new AutoCompleteEntities1();
            List<tblStudent> students;
            if (string.IsNullOrEmpty(searchTerm))
            {
                students = db.tblStudents.ToList();
            }
            else
            {
                students = db.tblStudents
                    .Where(s => s.Name.StartsWith(searchTerm)).ToList();
            }
            return View(students);
        }

        public JsonResult GetStudents(string term)
        {
            AutoCompleteEntities1 db = new AutoCompleteEntities1();
            List<string> students = db.tblStudents.Where(s => s.Name.StartsWith(term))
                .Select(x => x.Name).ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}