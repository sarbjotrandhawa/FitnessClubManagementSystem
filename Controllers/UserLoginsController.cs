using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FitnessClubManagementSystem.DAL;
using FitnessClubManagementSystem.Models;

namespace FitnessClubManagementSystem.Controllers
{
    public class UserLoginsController : Controller
    {
        private FitnessClubContext db = new FitnessClubContext();

        // GET: UserLogins
        public ActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "userID,userName,password")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    Customer obj = db.customers.Where(a => a.customerEmail.Equals(userLogin.userName) && a.password.Equals(userLogin.password)).FirstOrDefault();
                    if (obj != null)
                    {

                        Session["UserName"] = obj.customerName.ToString();
                        Session["ID"] = obj.customerId.ToString();

                        return RedirectToAction("Profile", new RouteValueDictionary(
new { controller = "Customers", action = "Profile", Id = obj.customerId }));
                        //return RedirectToAction("Index");

                        
                    }

                    else
                    {
                        ViewBag.Message = "Please enter valid username/password.";
                        return View();
                    }
                }
            }

               return View();
        }


        public new ActionResult Profile(int? id)
        {

            Customer customer = db.customers.Find(id);
            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
