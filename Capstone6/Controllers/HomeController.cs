using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone6.Models;

namespace Capstone6.Controllers
{
    public class HomeController : Controller
    {
        public TaskListEntities4 ORM = new TaskListEntities4();
        //public TaskListEntities3 ORM = new TaskListEntities3();
        
        public ActionResult Index()
        {
            ViewBag.ListOfTasks = ORM.Tasksses.ToList<Taskss>();
            return View();
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
        public ActionResult AddTask(Taskss task)
        {
            if (ModelState.IsValid)
            {
                ORM.Tasksses.Add(task);
                ORM.SaveChanges();
                return View("AddTask");
            }
            else
            {

            }
        }
    }
}