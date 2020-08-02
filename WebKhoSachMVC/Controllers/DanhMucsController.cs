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
    public class DanhMucsController : Controller
    {
        private KhoSachEntities db;
        //chay coi
        public DanhMucsController(KhoSachEntities context)
        {
            db = context;
        }

        // GET: DanhMucs
        public ActionResult Index()
        {
            var danhMucs = db.DanhMucs.Include(d => d.KeSach);
            return View(danhMucs.ToList());
        }

        // GET: DanhMucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // GET: DanhMucs/Create
        public ActionResult Create()
        {
            ViewBag.IdKeSach = new SelectList(db.KeSaches, "IdKeSach", "TenKeSach");
            return View();
        }

        // POST: DanhMucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDanhMuc,TheLoai,IdKeSach")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucs.Add(danhMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdKeSach = new SelectList(db.KeSaches, "IdKeSach", "TenKeSach", danhMuc.IdKeSach);
            return View(danhMuc);
        }

        // GET: DanhMucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdKeSach = new SelectList(db.KeSaches, "IdKeSach", "TenKeSach", danhMuc.IdKeSach);
            return View(danhMuc);
        }

        // POST: DanhMucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDanhMuc,TheLoai,IdKeSach")] DanhMuc danhMuc)
        {
            var entity = db.DanhMucs.Find(danhMuc.IdDanhMuc);
            if (entity == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                entity.IdKeSach = danhMuc.IdKeSach;
                entity.TheLoai = danhMuc.TheLoai; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdKeSach = new SelectList(db.KeSaches, "IdKeSach", "TenKeSach", danhMuc.IdKeSach);
            return View(danhMuc);
        }

        // GET: DanhMucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: DanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            db.DanhMucs.Remove(danhMuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
