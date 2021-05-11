using FitnessClubManagementSystem.DAL;
using FitnessClubManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessClubManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private FitnessClubContext db = new FitnessClubContext();
        public ActionResult Index()
        {
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

        public ActionResult Map()
        {
            ViewBag.Message = "Your contact page.";
            return View(db.Cities.ToList());
            
        }

        public ActionResult FrequentlyAskedQuestions()
        {
            return View();
        }

        public ActionResult GetCalendar()
        {
            return View("Calendar");
        }

        public JsonResult GetEvents()
        {
            using (db)
            {
                var events = db.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }

        public ActionResult EventVisuals()
        {
            return View();
        }


        public ActionResult logout()
        {
            Session.Abandon();
            return View("index", "Home");
        }


        [HttpPost]

        public ActionResult Contact([Bind(Include = "Id,FullName,Email,Message,FeedbackDate")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.FeedbackDate = DateTime.Now;
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                ViewBag.message = "We have recieved your information and contact your shortly.";
                return RedirectToAction("Contact");
            }

            else
            {
                return View();
            }

        }
    }
}