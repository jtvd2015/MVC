using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerProject.Models;

namespace CustomerProject.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerDbContext db = new CustomerDbContext();  //this is what talks to EF to read and get data

        //GET: Customers/OrdersForCustomer/5
        public ActionResult OrdersForCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersForCustomer ordersForCustomer = new OrdersForCustomer();  //instance will hold the one customer we need to view and all the orders for that specific customer
            ordersForCustomer.Customer = db.Customers.Find(id);  //this is going to reference the customer made in the OrdersForCustomer.cs file
            if (ordersForCustomer.Customer == null)
            {
                return HttpNotFound();
            }
            ordersForCustomer.Orders = db.Orders.Where(o => o.CustomerId == id).ToList();  //set the orders to the result for that specific customer id and it will bring back a list of orders by customer
            return View(ordersForCustomer);
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]  //if a create needs to be done, it needs to be a Post method, data needs to be sent to the system
        [ValidateAntiForgeryToken]  //
        public ActionResult Create([Bind(Include = "Id,Name,Sales,Active,DateCreated")] Customer customer)  //Includes means that the Id, Name, Sales, Active, DateCreated will be added when the Customer is created in the Customer instance
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index"); //after changes are saved successfully, this returns to Index with the newly added customer displayed in the Customer list
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Sales,Active,DateCreated")] Customer customer)
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
            Customer customer = db.Customers.Find(id);
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
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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