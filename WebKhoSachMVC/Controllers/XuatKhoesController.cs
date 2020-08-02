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
    public class XuatKhoesController : Controller
    {
        private KhoSachEntities db;

        public XuatKhoesController(KhoSachEntities context)
        {
            db = context;
        }
        // GET: XuatKhoes
        public ActionResult Index()
        {
            var xuatKhoes = db.XuatKhoes.Include(x => x.Sach);
            return View(xuatKhoes.ToList());
        }

        // GET: XuatKhoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XuatKho xuatKho = db.XuatKhoes.Find(id);
            if (xuatKho == null)
            {
                return HttpNotFound();
            }
            return View(xuatKho);
        }

        // GET: XuatKhoes/Create
        public ActionResult Create()
        {
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach");
            return View();
        }

        // POST: XuatKhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdXKho,NgayXuat,IdSach,Soluongxuat")] XuatKho xuatKho)
        {
            if (ModelState.IsValid)
            {
                db.XuatKhoes.Add(xuatKho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", xuatKho.IdSach);
            return View(xuatKho);
        }

        // GET: XuatKhoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XuatKho xuatKho = db.XuatKhoes.Find(id);
            if (xuatKho == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", xuatKho.IdSach);
            return View(xuatKho);
        }

        // POST: XuatKhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdXKho,NgayXuat,IdSach,Soluongxuat")] XuatKho xuatKho)
        {
            var entity = db.XuatKhoes.Find(xuatKho.IdXKho);
            if (entity == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                entity.NgayXuat = xuatKho.NgayXuat;
                entity.IdSach = xuatKho.IdSach;
                entity.Soluongxuat = xuatKho.Soluongxuat;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", xuatKho.IdSach);
            return View(xuatKho);
        }

        // GET: XuatKhoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XuatKho xuatKho = db.XuatKhoes.Find(id);
            if (xuatKho == null)
            {
                return HttpNotFound();
            }
            return View(xuatKho);
        }

        // POST: XuatKhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            XuatKho xuatKho = db.XuatKhoes.Find(id);
            db.XuatKhoes.Remove(xuatKho);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
