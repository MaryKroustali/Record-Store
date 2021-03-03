using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;
using System.Data.SqlClient;

namespace WebApplication8.Controllers
{
    public class CustomersController : Controller
    {
        private ChinookEntities db = new ChinookEntities();

        // GET: Customers
        public ActionResult Index()
        {
            var customer = db.Customer.Include(c => c.Employee);
            return View(customer.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.SupportRepId = new SelectList(db.Employee, "EmployeeId", "LastName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,Company,Address,City,State,Country,PostalCode,Phone,Fax,Email,SupportRepId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupportRepId = new SelectList(db.Employee, "EmployeeId", "LastName", customer.SupportRepId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupportRepId = new SelectList(db.Employee, "EmployeeId", "LastName", customer.SupportRepId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,Company,Address,City,State,Country,PostalCode,Phone,Fax,Email,SupportRepId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupportRepId = new SelectList(db.Employee, "EmployeeId", "LastName", customer.SupportRepId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
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
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
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


        public ActionResult Input()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Input(string date1, string date2)
        {
            string since = date1;
            string till = date2;
            if (since == "" && till == "")
            {
                return RedirectToAction("Input");
            }
            else if (since == "")
            {
                since = "2009-01-01";
            }
            else if (till == "")
            {
                till = "2100-01-01";
            }
            using (var context = new ChinookEntities())
            {
                var data = context.Customer.SqlQuery("[dbo].[query4] @StartDate, @StopDate",
                    new SqlParameter("StartDate", since),
                    new SqlParameter("StopDate", till)).ToList();
                TempData["data"] = data;
                return RedirectToAction("show");
               
            }
        }

        public ActionResult show()
        {
            var result = TempData["data"];
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return RedirectToAction("Input");
            }
        }
        public ActionResult Input1()
        {
            ViewBag.CustomerF = new SelectList(db.Customer, "CustomerId", "FirstName");
            ViewBag.CustomerL = new SelectList(db.Customer, "CustomerId", "Lastname");
            ViewBag.EmployeeF = new SelectList(db.Employee, "EmployeeId", "FirstName");
            ViewBag.EmployeeL = new SelectList(db.Employee, "EmployeeId", "LastName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Input1(string EmployeeFirst, string EmployeeLast, string CustomerFirst, string CustomerLast, string date1, string date2)
        {
            string since = date1;
            string till = date2;
            string customerF = CustomerFirst; //roberto
            string customerL = CustomerLast;  //"Almeida";    
            string employeeF = EmployeeFirst;
            string employeeL = EmployeeLast;
      
            if (since == "")
            {
                since = "2009-01-01";
            }
            if (till == "")
            {
                till = "2100-01-01";
            }

            using (var context = new ChinookEntities())
            {

                var data = context.Customer.SqlQuery("[dbo].[query5] @StartDate, @StopDate, " +
                    "@customerFirst, @CustomerLast ," +
                    "@employeeFirst ,@EmployeeLast",
                    new SqlParameter("StartDate", since),
                    new SqlParameter("StopDate", till),
                    new SqlParameter("customerFirst", customerF),
                    new SqlParameter("CustomerLast", customerL),
                    new SqlParameter("employeeFirst", employeeF),
                    new SqlParameter("EmployeeLast", employeeL)).ToList();
                TempData["data"] = data;
                return RedirectToAction("show1");
            }
        }
        public ActionResult Show1()
        {

            var result = TempData["data"];

            if (result != null)
            {
                return View(result);
            }
            else
            {
                return RedirectToAction("Input1");
            }
        }
    }

}
    
