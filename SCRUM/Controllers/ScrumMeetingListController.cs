using SCRUM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SQLite;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHibernate.Cfg;
using NHibernate;

namespace SCRUM.Controllers
{
    public class ScrumMeetingListController : Controller
    {
        public JsonScrumRepository ScrumRepository { get; private set; }

        public ScrumMeetingListController()
        {
            this.ScrumRepository = new JsonScrumRepository();
        }
       
        [HttpGet]
        public ActionResult Index()
        {
            return View(ScrumRepository.GetAll());
        } 
    }
}