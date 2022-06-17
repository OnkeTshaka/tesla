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
    public class ApprovalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(FormCollection form)
        {
            var car_id = int.Parse(form["car_id"]);
            var rating = int.Parse(form["Rating"]);

            Approval artComment = new Approval()
            {
                car_id = car_id,
                Rating = rating,
                ThisDateTime = DateTime.Now
            };

            db.Approval.Add(artComment);
            db.SaveChanges();

            return RedirectToAction("Details", "Cars", new { id = car_id });
        }
        // GET: Approvals
        public ActionResult Index()
        {
            return View(db.Approval.ToList());
        }

        // GET: Approvals/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approval.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // GET: Approvals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Approvals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,ThisDateTime,car_id,Rating")] Approval approval)
        {
            if (ModelState.IsValid)
            {
                approval.CommentId = Guid.NewGuid();
                db.Approval.Add(approval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(approval);
        }

        // GET: Approvals/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approval.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // POST: Approvals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,ThisDateTime,car_id,Rating")] Approval approval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(approval);
        }

        // GET: Approvals/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approval.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // POST: Approvals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Approval approval = db.Approval.Find(id);
            db.Approval.Remove(approval);
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
