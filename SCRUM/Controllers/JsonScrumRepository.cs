using Newtonsoft.Json;
using NHibernate.Linq;
using SCRUM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Hosting;
using System.Web.Script.Serialization;

namespace SCRUM.Controllers
{
    public class JsonScrumRepository
    {
        public List<Task> Tasks;
        public JsonScrumRepository()
        {      
        }
        public List<Task> GetAll()
        {
            // ---- FROM DATABASE ---- ////
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Tasks = session.Query<Task>().ToList();
                }
            }
            return Tasks;
        }

        public Task Get(int id)
        {
            Task task = new Task();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    task = session.Get<Task>(id);
                }
            }
            
            return task;
        }

        public void AddTask(Task task)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(task);
                    transaction.Commit();
                }
            }
        }
    }
}