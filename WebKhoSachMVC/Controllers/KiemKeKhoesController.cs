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
    public class KiemKeKhoesController : Controller
    {
        private KhoSachEntities db;

        public KiemKeKhoesController(KhoSachEntities context)
        {
            db = context;
        }
        // GET: KiemKeKhoes
        public ActionResult Index()
        {
            var kiemKeKhoes = db.KiemKeKhoes.Include(k => k.NhapKho).Include(k => k.Sach).Include(k => k.XuatKho);
            return View(kiemKeKhoes.ToList());
        }

        // GET: KiemKeKhoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KiemKeKho kiemKeKho = db.KiemKeKhoes.Find(id);
            if (kiemKeKho == null)
            {
                return HttpNotFound();
            }
            return View(kiemKeKho);
        }

        // GET: KiemKeKhoes/Create
        public ActionResult Create()
        {
            ViewBag.IdNKho = new SelectList(db.NhapKhoes, "IdNKho", "IdNKho");
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach");
            ViewBag.IdXKho = new SelectList(db.XuatKhoes, "IdXKho", "IdXKho");
            return View();
        }

        // POST: KiemKeKhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdKiemKho,IdXKho,IdNKho,IdSach")] KiemKeKho kiemKeKho)
        {
            if (ModelState.IsValid)
            {
                db.KiemKeKhoes.Add(kiemKeKho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdNKho = new SelectList(db.NhapKhoes, "IdNKho", "IdNKho", kiemKeKho.IdNKho);
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", kiemKeKho.IdSach);
            ViewBag.IdXKho = new SelectList(db.XuatKhoes, "IdXKho", "IdXKho", kiemKeKho.IdXKho);
            return View(kiemKeKho);
        }

        // GET: KiemKeKhoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KiemKeKho kiemKeKho = db.KiemKeKhoes.Find(id);
            if (kiemKeKho == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdNKho = new SelectList(db.NhapKhoes, "IdNKho", "IdNKho", kiemKeKho.IdNKho);
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", kiemKeKho.IdSach);
            ViewBag.IdXKho = new SelectList(db.XuatKhoes, "IdXKho", "IdXKho", kiemKeKho.IdXKho);
            return View(kiemKeKho);
        }

        // POST: KiemKeKhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdKiemKho,IdXKho,IdNKho,IdSach")] KiemKeKho kiemKeKho)
        {
            var entity = db.KiemKeKhoes.Find(kiemKeKho.IdKiemKho);
            if (entity == null)
                return HttpNotFound();
            if (ModelState.IsValid)
            {
                entity.IdXKho = kiemKeKho.IdXKho;
                entity.IdNKho = kiemKeKho.IdNKho;
                entity.IdSach = kiemKeKho.IdSach;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdNKho = new SelectList(db.NhapKhoes, "IdNKho", "IdNKho", kiemKeKho.IdNKho);
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", kiemKeKho.IdSach);
            ViewBag.IdXKho = new SelectList(db.XuatKhoes, "IdXKho", "IdXKho", kiemKeKho.IdXKho);
            return View(kiemKeKho);
        }

        // GET: KiemKeKhoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KiemKeKho kiemKeKho = db.KiemKeKhoes.Find(id);
            if (kiemKeKho == null)
            {
                return HttpNotFound();
            }
            return View(kiemKeKho);
        }

        // POST: KiemKeKhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KiemKeKho kiemKeKho = db.KiemKeKhoes.Find(id);
            db.KiemKeKhoes.Remove(kiemKeKho);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
