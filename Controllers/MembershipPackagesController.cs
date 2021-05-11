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
    [Authorize]
    public class MembershipPackagesController : Controller
    {
        private FitnessClubContext db = new FitnessClubContext();

        // GET: MembershipPackages
        public ActionResult Index()
        {
            return View(db.membershipPackages.ToList());
        }

        // GET: MembershipPackages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipPackages membershipPackages = db.membershipPackages.Find(id);
            if (membershipPackages == null)
            {
                return HttpNotFound();
            }
            return View(membershipPackages);
        }

        // GET: MembershipPackages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembershipPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "packageId,name,description,price")] MembershipPackages membershipPackages)
        {
            if (ModelState.IsValid)
            {
                db.membershipPackages.Add(membershipPackages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membershipPackages);
        }

        // GET: MembershipPackages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipPackages membershipPackages = db.membershipPackages.Find(id);
            if (membershipPackages == null)
            {
                return HttpNotFound();
            }
            return View(membershipPackages);
        }

        // POST: MembershipPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "packageId,name,description,price")] MembershipPackages membershipPackages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membershipPackages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membershipPackages);
        }

        // GET: MembershipPackages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipPackages membershipPackages = db.membershipPackages.Find(id);
            if (membershipPackages == null)
            {
                return HttpNotFound();
            }
            return View(membershipPackages);
        }

        // POST: MembershipPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MembershipPackages membershipPackages = db.membershipPackages.Find(id);
            db.membershipPackages.Remove(membershipPackages);
            db.SaveChanges();
            return RedirectToAction("Index");
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
