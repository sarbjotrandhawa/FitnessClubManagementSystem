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
using PagedList;

namespace FitnessClubManagementSystem.Controllers
{

    public class CustomersController : Controller
    {
        private FitnessClubContext db = new FitnessClubContext();

     
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.customerNameSortParm = String.IsNullOrEmpty(sortOrder) ? "customerName_asc" : "";
            ViewBag.customerphoneSortParm = sortOrder == "customerphone" ? "customerphone_desc" : "customerphone";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var customerList = from s in db.customers
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                customerList = customerList.Where(s => s.customerName.Contains(searchString)
                                     );

            }
            switch (sortOrder)
            {
                case "customerName_asc":
                    customerList = customerList.OrderBy(s => s.customerName);

                    break;
                case "customerphone":
                    customerList = customerList.OrderBy(s => s.customerphone);
                    break;
                case "customerphone_desc":
                    customerList = customerList.OrderByDescending(s => s.customerphone);
                    break;
                default:
                    customerList = customerList.OrderBy(s => s.customerId);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(customerList.ToPagedList(pageNumber, pageSize));


        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerId,customerName,password,customerEmail,customerphone,customerAddress,dateofbirth")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Enrollment", new RouteValueDictionary(
 new { controller = "Customers", action = "Enrollment", Id = customer.customerId }));
                //return RedirectToAction("Index");
            }
            return View(customer);
        }


        public ActionResult Enrollment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        
            ViewBag.customerId = id;
            ViewBag.clubId = new SelectList(db.clubs, "clubId", "clubStAddress");
            ViewBag.packageId = new SelectList(db.membershipPackages, "packageId", "name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enrollment([Bind(Include = "enrolementId,packageId,numberofmonths,clubId,customerId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Payment", new RouteValueDictionary(
                new { controller = "Customers", action = "Payment", Id = enrollment.enrolementId }));
                //return RedirectToAction("Index");
            }
            return View(enrollment);
        }

    public ActionResult Payment(int? id)
    {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Enrollment enrolment = db.Enrollments.Find(id);
            int month = enrolment.numberofmonths;
            MembershipPackages membershipPackage = db.membershipPackages.Find(enrolment.packageId);
            int price = membershipPackage.price;

            int totalamount = month * price;
            ViewBag.enrolementId = id;
            ViewBag.amount = totalamount;
            ViewBag.customerId = enrolment.customerId;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment([Bind(Include = "transactionId,amount,cardNumber,expiryDate,CVV,customerId,enrolementId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Profile", new RouteValueDictionary(
                new { controller = "Customers", action = "Profile", Id = payment.customerId }));
            }

            return View(payment);
        }

        public ActionResult Profile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
         //   string loggedUsername = Session["UserName"].ToString();
            if (null != Session["UserName"])
            {
                Customer customer = db.customers.Find(id);
                return View(customer);
            }
            else
            {
                return RedirectToAction("Index","Customers");
            }      
        }


        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerId,customerName,password,customerEmail,customerphone,customerAddress,dateofbirth")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.customers.Find(id);
            db.customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BookSlot()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            ViewBag.BookDate = tomorrow.ToString("d");
            return  View();
        }

        public ActionResult SlotNotification(FormCollection coll)
        {
            string loggedUsername = Session["UserName"].ToString();
            int id = Int32.Parse(Session["ID"].ToString()) ;
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            ViewBag.BookDate = tomorrow.ToString("d");


            if (ModelState.IsValid)
            {
                Slots s = new Slots();
                s.customerId = id;
                s.date = tomorrow;
                s.slotTimeID = coll["slot"].ToString();

                Enrollment e = db.Enrollments.Where(a => a.customerId.Equals(id)).FirstOrDefault();

                s.clubId = e.clubId;

                db.slots.Add(s);
                db.SaveChanges();
                ViewBag.confirm = "Slot is booked.";

                return RedirectToAction("Profile", new RouteValueDictionary(
                new { controller = "Customers", action = "Profile", Id = id }));
                //return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult BookingHistory()
        {
            int id = Int32.Parse(Session["ID"].ToString());
            var s = db.slots.Where(a => a.customerId.Equals(id));
            if(s!=null)
            {
                return View(s);
            }
            else
            {
                ViewBag.message = "No History Found";
                return View();
            }
           
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
