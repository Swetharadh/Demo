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
    public class MembersController : Controller
    {
        private dbWakenBakeEntities db = new dbWakenBakeEntities();

        // GET: Members
        public ActionResult Index()
        {
            return View(db.Tbl_Members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Members tbl_Members = db.Tbl_Members.Find(id);
            if (tbl_Members == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Members);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,FristName,LastName,EmailId,Password,IsActive,IsDelete,CreatedOn,ModifiedOn")] Tbl_Members tbl_Members)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Members.Add(tbl_Members);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Members);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Members tbl_Members = db.Tbl_Members.Find(id);
            if (tbl_Members == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Members);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,FristName,LastName,EmailId,Password,IsActive,IsDelete,CreatedOn,ModifiedOn")] Tbl_Members tbl_Members)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Members).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Members);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Members tbl_Members = db.Tbl_Members.Find(id);
            if (tbl_Members == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Members tbl_Members = db.Tbl_Members.Find(id);
            db.Tbl_Members.Remove(tbl_Members);
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
