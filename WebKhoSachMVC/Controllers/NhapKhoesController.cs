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
    [QuyenTk(Quyen.Admin)]
    public class NhapKhoesController : Controller
    {
        private KhoSachEntities db;

        public NhapKhoesController(KhoSachEntities context)
        {
            db = context;
        }
        // GET: NhapKhoes
        public ActionResult Index()
        {
            var nhapKhoes = db.NhapKhoes.Include(n => n.Sach);
            return View(nhapKhoes.ToList());
        }

        // GET: NhapKhoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho nhapKho = db.NhapKhoes.Find(id);
            if (nhapKho == null)
            {
                return HttpNotFound();
            }
            return View(nhapKho);
        }

        // GET: NhapKhoes/Create
        public ActionResult Create()
        {
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach");
            return View();
        }

        // POST: NhapKhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNKho,NgayNhap,IdSach,Soluongnhap")] NhapKho nhapKho)
        {
            if (ModelState.IsValid)
            {
                db.NhapKhoes.Add(nhapKho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", nhapKho.IdSach);
            return View(nhapKho);
        }

        // GET: NhapKhoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho nhapKho = db.NhapKhoes.Find(id);
            if (nhapKho == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", nhapKho.IdSach);
            return View(nhapKho);
        }

        // POST: NhapKhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNKho,NgayNhap,IdSach,Soluongnhap")] NhapKho nhapKho)
        {
            var entity = db.NhapKhoes.Find(nhapKho.IdNKho);
            if (entity == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                entity.NgayNhap = nhapKho.NgayNhap;
                entity.IdSach = nhapKho.IdSach;
                entity.Soluongnhap = nhapKho.Soluongnhap;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", nhapKho.IdSach);
            return View(nhapKho);
        }

        // GET: NhapKhoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho nhapKho = db.NhapKhoes.Find(id);
            if (nhapKho == null)
            {
                return HttpNotFound();
            }
            return View(nhapKho);
        }

        // POST: NhapKhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhapKho nhapKho = db.NhapKhoes.Find(id);
            db.NhapKhoes.Remove(nhapKho);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
