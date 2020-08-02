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
    
    public class KhoSachesController : Controller
    {
        private KhoSachEntities db;

        public KhoSachesController(KhoSachEntities context)
        {
            db = context;
        }

        // GET: KhoSaches
        public ActionResult Index(string searchString)
        {
            var links = from l in db.KhoSaches
                        select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.TenKho.Contains(searchString));
            }

            return View(links);
        }

        // GET: KhoSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoSach khoSach = db.KhoSaches.Find(id);
            if (khoSach == null)
            {
                return HttpNotFound();
            }
            return View(khoSach);
        }

        // GET: KhoSaches/Create
        public ActionResult Create()
        {
            ViewBag.IdKiemKho = new SelectList(db.KiemKeKhoes, "IdKiemKho", "IdKiemKho");
            ViewBag.IdTKKho = new SelectList(db.ThongKeKhoes, "IdTKKho", "IdTKKho");
            return View();
        }

        // POST: KhoSaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdKho,TenKho,TenNhanVien,IdTKKho,IdKiemKho")] KhoSach khoSach)
        {
            if (ModelState.IsValid)
            {
                db.KhoSaches.Add(khoSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdKiemKho = new SelectList(db.KiemKeKhoes, "IdKiemKho", "IdKiemKho", khoSach.IdKiemKho);
            ViewBag.IdTKKho = new SelectList(db.ThongKeKhoes, "IdTKKho", "IdTKKho", khoSach.IdTKKho);
            return View(khoSach);
        }

        // GET: KhoSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoSach khoSach = db.KhoSaches.Find(id);
            if (khoSach == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdKiemKho = new SelectList(db.KiemKeKhoes, "IdKiemKho", "IdKiemKho", khoSach.IdKiemKho);
            ViewBag.IdTKKho = new SelectList(db.ThongKeKhoes, "IdTKKho", "IdTKKho", khoSach.IdTKKho);
            return View(khoSach);
        }

        // POST: KhoSaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdKho,TenKho,TenNhanVien,IdTKKho,IdKiemKho")] KhoSach khoSach)
        {
            var entity = db.KhoSaches.Find(khoSach.IdKho);
            if (entity == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                entity.TenKho = khoSach.TenKho;
                entity.TenNhanVien = khoSach.TenNhanVien;
                entity.IdTKKho = khoSach.IdTKKho;
                entity.IdKiemKho = khoSach.IdKiemKho;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdKiemKho = new SelectList(db.KiemKeKhoes, "IdKiemKho", "IdKiemKho", khoSach.IdKiemKho);
            ViewBag.IdTKKho = new SelectList(db.ThongKeKhoes, "IdTKKho", "IdTKKho", khoSach.IdTKKho);
            return View(khoSach);
        }

        // GET: KhoSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoSach khoSach = db.KhoSaches.Find(id);
            if (khoSach == null)
            {
                return HttpNotFound();
            }
            return View(khoSach);
        }

        // POST: KhoSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhoSach khoSach = db.KhoSaches.Find(id);
            db.KhoSaches.Remove(khoSach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
