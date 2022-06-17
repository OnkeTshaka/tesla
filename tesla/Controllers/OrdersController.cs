using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tesla.Models;

namespace tesla.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }
        #region Refactored functions
              public string GenerateRefCode()
        {
            Random randm = new Random();
            string upr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string downr = "abcdefghijklmnopqrstuvwxyz";
            string digir = "1234567890";
            char[] tno = new char[8];
            int r1 = randm.Next(0, 25);
            int r2 = randm.Next(0, 25);
            int r3 = randm.Next(0, 9);
            tno[0] = upr[r1];
            tno[1] = downr[r2];
            tno[2] = digir[r3];
            r1 = randm.Next(0, 25);
            r2 = randm.Next(0, 25);
            r3 = randm.Next(0, 9);
            tno[3] = upr[r2];
            tno[4] = downr[r1];
            tno[5] = digir[r3];
            string t_no = new string(tno);

            return new string(tno);
        }

        public void MyOrder(Order order)
        {
            List<CartItem> cartItems = (List<CartItem>)Session["cart"];
            foreach (CartItem cart in cartItems)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderID  = order.OrderID,
                    car_id = cart.Car.id,
                    Quantity = cart.Quantity,
                    Price = cart.Car.price
                };
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }
        }

        public string Client(Order order)
        {
            string CurrentUserName = User.Identity.GetUserName();
            order.CustomerName = CurrentUserName;
            return CurrentUserName;
        }
        #endregion
        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerName,CustomerPhone,CustomerEmail,CustomerAddress,Refcode,From,OrderDate,PaymentType,Status")] Order order)
        {

            if (ModelState.IsValid)
            {

                order.Refcode = GenerateRefCode();
                order.OrderDate = DateTime.Now;
                Client(order);
                order.From = "Berea Centre Road, Bulwer, Berea, South Africa";
                if (order.Status == null)
                {
                    order.Status = "Pending";
                }


                db.Orders.Add(order);
                db.SaveChanges();
                MyOrder(order);

                Session.Remove("cart");
                Session.Remove("count");
            }
                return RedirectToAction("Details", "Orders", new { id = order.OrderID });
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerName,CustomerPhone,CustomerEmail,CustomerAddress,Refcode,From,OrderDate,PaymentType,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
