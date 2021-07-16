using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WakenBake.DAL;

namespace WakenBake.Controllers
{
    public class ShippingDetailsController : Controller
    {
        private dbWakenBakeEntities db = new dbWakenBakeEntities();

        // GET: ShippingDetails
        public ActionResult Index()
        {
            var tbl_ShippingDetails = db.Tbl_ShippingDetails.Include(t => t.Tbl_Members).Include(t => t.Tbl_Members1).Include(t => t.Tbl_Members2);
            return View(tbl_ShippingDetails.ToList());
        }

        // GET: ShippingDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_ShippingDetails tbl_ShippingDetails = db.Tbl_ShippingDetails.Find(id);
            if (tbl_ShippingDetails == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ShippingDetails);
        }

        // GET: ShippingDetails/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName");
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName");
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName");
            return View();
        }

        // POST: ShippingDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingDetailId,MemberId,Adress,City,State,Country,ZipCode,OrderId,AmountPaid,PaymentType")] Tbl_ShippingDetails tbl_ShippingDetails)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_ShippingDetails.Add(tbl_ShippingDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName", tbl_ShippingDetails.MemberId);
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName", tbl_ShippingDetails.MemberId);
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName", tbl_ShippingDetails.MemberId);
            return View(tbl_ShippingDetails);
        }

        // GET: ShippingDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_ShippingDetails tbl_ShippingDetails = db.Tbl_ShippingDetails.Find(id);
            if (tbl_ShippingDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName", tbl_ShippingDetails.MemberId);
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName", tbl_ShippingDetails.MemberId);
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName", tbl_ShippingDetails.MemberId);
            return View(tbl_ShippingDetails);
        }

        // POST: ShippingDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingDetailId,MemberId,Adress,City,State,Country,ZipCode,OrderId,AmountPaid,PaymentType")] Tbl_ShippingDetails tbl_ShippingDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ShippingDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName", tbl_ShippingDetails.MemberId);
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName", tbl_ShippingDetails.MemberId);
            ViewBag.MemberId = new SelectList(db.Tbl_Members, "MemberId", "FristName", tbl_ShippingDetails.MemberId);
            return View(tbl_ShippingDetails);
        }

        // GET: ShippingDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_ShippingDetails tbl_ShippingDetails = db.Tbl_ShippingDetails.Find(id);
            if (tbl_ShippingDetails == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ShippingDetails);
        }

        // POST: ShippingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_ShippingDetails tbl_ShippingDetails = db.Tbl_ShippingDetails.Find(id);
            db.Tbl_ShippingDetails.Remove(tbl_ShippingDetails);
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
