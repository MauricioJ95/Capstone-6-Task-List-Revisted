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
        public TaskListEntities5 ORM = new TaskListEntities5();
        
        public ActionResult Index()
        {
            ViewBag.ListOfTasks = ORM.Tasksses.ToList<Taskss>();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("AddingTasks");
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
                return View("AddingTask");
            }
            else
            {
                return View("AddingTask");
            }
        }
        public ActionResult AddingTask()
        {
            return View();
        }
    }
}