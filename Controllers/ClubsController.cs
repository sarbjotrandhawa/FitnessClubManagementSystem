using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessClubManagementSystem.DAL;
using FitnessClubManagementSystem.Models;

namespace FitnessClubManagementSystem.Controllers
{
   
    public class ClubsController : Controller
    {
        private FitnessClubContext db = new FitnessClubContext();

        // GET: Clubs
        public ActionResult Index()
        {
            return View(db.clubs.ToList());
        }


        public ActionResult FindClub()
        {
            return View();
        }

        // GET: Clubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clubId,clubStAddress,clubCity,clubProvince,clubPostal")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.clubs.Add(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(club);
        }

        // GET: Clubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clubId,clubStAddress,clubCity,clubProvince,clubPostal")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(club);
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Club club = db.clubs.Find(id);
            db.clubs.Remove(club);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult ClubDetail(FormCollection coll)
        {
            string club = coll["SelectClub"].ToString();
           
            var clublist = new List<Club>();
            if (club.Equals("") || club.Equals(""))
            {
                ViewBag.Message = "Please select a Province.";
                return View("Error");
            }
            else
            {
                
                        using (db)
                        {
                            clublist = db.clubs.Where(x => x.clubProvince.Equals(club)).ToList();
                        }
                    
            }

            if (clublist.Count.Equals(0))
            {
                ViewBag.Message = "Gym is not available in this province.";
            }
            return View(clublist);
        }

        public ActionResult Feedbackdetail()
        {
            return View(db.Feedbacks.ToList());
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
