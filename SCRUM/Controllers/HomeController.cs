using SCRUM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCRUM.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //Nie mam bazy danych wiec statycznie stworze jeden obiekt
            Task temp = new Task()
            {
                whatIhaveDone = "widok",
                whatIwillDo = "model",
                whatProblemsIgot = "baza danych",
                whoMadePost = "Kuba",
                dateOfPost = DateTime.Now
            };
            ViewBag.temp = temp;
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(Task task)
        {
            //Trzeba zrobić zapis do bazy danych przesłanego z formularza SMR'a
            return View();
        }
    }
}