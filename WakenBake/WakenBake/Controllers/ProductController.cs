using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WakenBake.DAL;

namespace WakenBake.Controllers
{
    public class ProductController : Controller
    {
        private dbWakenBakeEntities db = new dbWakenBakeEntities();

        // GET: Product
       
        public ActionResult Index()
        {
            var tbl_Product = db.Tbl_Product.Include(t => t.Tbl_Category);
            return View(tbl_Product.ToList());
        }

        // GET: Product/Details/5

        public ActionResult Details(int? id)
        {
           
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tbl_Product tbl_Product = db.Tbl_Product.Find(id);
                if (tbl_Product == null)
                {
                    return HttpNotFound();
                }

                //List<Tbl_Members> tbl_member = db.Tbl_Members.ToList();

                //dynamic data = new ExpandoObject();
                //data._product = tbl_Product;
                //data._subscribers = tbl_member;

                //return View(data);
                return View();
            }

        }

     
      
        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Tbl_Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,CategoryId,IsActive,IsDelete,CreatedDate,ModifiedDate,ProductImage,IsFeatured,Quantity,Price,ShortDescription,TralierLink,Director,Actors,Producer,Writer,Rating,Movietime,ReleaseDate")] Tbl_Product tbl_Product, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImage/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl_Product.ProductImage = pic;
            if (ModelState.IsValid)
            {
                db.Tbl_Product.Add(tbl_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Tbl_Category, "CategoryId", "CategoryName", tbl_Product.CategoryId);
            return View(tbl_Product);
        }
       
        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product tbl_Product = db.Tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Tbl_Category, "CategoryId", "CategoryName", tbl_Product.CategoryId);
            return View(tbl_Product);
        }
       
        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,CategoryId,IsActive,IsDelete,CreatedDate,ModifiedDate,ProductImage,IsFeatured,Quantity,Price,ShortDescription,TralierLink,Director,Actors,Producer,Writer,Rating,Movietime,ReleaseDate")] Tbl_Product tbl_Product, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImage/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl_Product.ProductImage = file != null ? pic : tbl_Product.ProductImage;
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Tbl_Category, "CategoryId", "CategoryName", tbl_Product.CategoryId);
            return View(tbl_Product);
        }
        
        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product tbl_Product = db.Tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }
        
        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Product tbl_Product = db.Tbl_Product.Find(id);
            db.Tbl_Product.Remove(tbl_Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private ActionResult RedirectToAction(Func<ActionResult> index)
        {
            throw new NotImplementedException();
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
