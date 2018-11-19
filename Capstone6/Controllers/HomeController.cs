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
        public TaskListEntities7 ORM = new TaskListEntities7();

        public ActionResult AddUser()
        {
            return View("Index");
        }
        public ActionResult Index()
        {
            ViewBag.ListOfTasks = ORM.Taskssses.ToList<Tasksss>();
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
        public ActionResult AddTask(Tasksss task)
        {
            if (ModelState.IsValid)
            {
                ORM.Taskssses.Add(task);
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
            ViewBag.ListOfTasks = ORM.Taskssses.ToList<Tasksss>();
            return View();
        }
        public ActionResult EditTask(int taskID, Tasksss NewTask)
        {
            Tasksss found = ORM.Taskssses.Find(taskID);
            ViewBag.Task = found;

            if (found != null)
            {
                
                Tasksss oldTask = ORM.Taskssses.Find(NewTask.TaskID);
                oldTask.Description = NewTask.Description;
                oldTask.DueDate = NewTask.DueDate;
                oldTask.Completion = NewTask.Completion;

                ORM.Entry(oldTask).State = System.Data.Entity.EntityState.Modified;
                ORM.SaveChanges();
                return View("Index");
            }
            return View("Index");
        }

        public ActionResult ToggleStatus(int taskID)
        {
            Tasksss ItemToToggle = ORM.Taskssses.Find(taskID);
            if(ItemToToggle.Completion == true)
            {
                ItemToToggle.Completion = false;
            }
            else
            {
                ItemToToggle.Completion = true;
            }
            ORM.Entry(ItemToToggle).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteItem(int taskID)

        {

            Tasksss ItemToDelete = ORM.Taskssses.Find(taskID);

            ORM.Taskssses.Remove(ItemToDelete);
            
            ORM.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}