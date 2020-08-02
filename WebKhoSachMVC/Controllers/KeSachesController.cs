using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebKhoSachMVC.Models;
using WebKhoSachMVC.Mvc;

namespace WebKhoSachMVC.Controllers
{
    [QuyenTk(Quyen.NhanVien)]
    public class KeSachesController : Controller
    {
        private readonly KhoSachEntities db;

        public KeSachesController(KhoSachEntities context)
        {
            db = context;
        }

        // GET: KeSaches
        public ActionResult Index()
        {
            return View(db.KeSaches.ToList());
        }

        // GET: KeSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeSach keSach = db.KeSaches.Find(id);
            if (keSach == null)
            {
                return HttpNotFound();
            }
            return View(keSach);
        }

        // GET: KeSaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KeSaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdKeSach,TenKeSach,ViTri")] KeSach keSach)
        {
            if (ModelState.IsValid)
            {
                db.KeSaches.Add(keSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(keSach);
        }

        // GET: KeSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeSach keSach = db.KeSaches.Find(id);
            if (keSach == null)
            {
                return HttpNotFound();
            }
            return View(keSach);
        }

        // POST: KeSaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdKeSach,TenKeSach,ViTri")] KeSach keSach)
        {
            var entity = db.KeSaches.Find(keSach.IdKeSach);
            if (entity == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                entity.TenKeSach = keSach.TenKeSach;
                entity.ViTri = keSach.ViTri;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(keSach);
        }

        // GET: KeSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeSach keSach = db.KeSaches.Find(id);
            if (keSach == null)
            {
                return HttpNotFound();
            }
            return View(keSach);
        }

        // POST: KeSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KeSach keSach = db.KeSaches.Find(id);
            db.KeSaches.Remove(keSach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
