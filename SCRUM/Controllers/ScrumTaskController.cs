using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCRUM.Models;

namespace SCRUM.Controllers
{
    public class ScrumTaskController : Controller
    {
        public JsonScrumRepository ScrumRepository { get; private set; }

        public ScrumTaskController()
        {
            this.ScrumRepository = new JsonScrumRepository();
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var task = ScrumRepository.Get(id);
            return View(task);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task, bool currentDate, string managedDate)
        {
            //-- DOPISZ DATE --//
            if (currentDate)
            {
                DateTime date = DateTime.Now;
                task.DateOfPost = date.Date.ToString("d");
            }
            else
            {
                string year = managedDate.Substring(0, 4);
                string month = managedDate.Substring(5, 2);
                string day = managedDate.Substring(8, 2);
                managedDate = day + "." + month + "." + year;
                task.DateOfPost = managedDate;
            }         

            //-- PRZYDZIEL INDEKS --//
            ScrumRepository.Tasks = ScrumRepository.GetAll();
            if (ScrumRepository.Tasks.Count == 0)
                task.ID = 0;
            else
                task.ID = ScrumRepository.Tasks.First().ID + 1;

            //-- DODAJ DO REPOZYTORIUM --//
            ScrumRepository.AddTask(task);

            return RedirectToAction("Index", "ScrumMeetingList");
        }
    }
}