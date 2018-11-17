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
        public TaskListEntities2 ORM = new TaskListEntities2();
        
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
    }
}