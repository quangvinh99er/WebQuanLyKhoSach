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
   
    public class ThongKeKhoesController : Controller
    {
        private KhoSachEntities db;

        public ThongKeKhoesController(KhoSachEntities context)
        {
            db = context;
        }

        // GET: ThongKeKhoes
        public ActionResult Index()
        {
            var thongKeKhoes = db.ThongKeKhoes.Include(t => t.Sach);
            return View(thongKeKhoes.ToList());
        }

        // GET: ThongKeKhoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongKeKho thongKeKho = db.ThongKeKhoes.Find(id);
            if (thongKeKho == null)
            {
                return HttpNotFound();
            }
            return View(thongKeKho);
        }

        // GET: ThongKeKhoes/Create
        public ActionResult Create()
        {
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach");
            return View();
        }

        // POST: ThongKeKhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTKKho,NgayTK,SoLuongTon,IdSach")] ThongKeKho thongKeKho)
        {
            if (ModelState.IsValid)
            {
                db.ThongKeKhoes.Add(thongKeKho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", thongKeKho.IdSach);
            return View(thongKeKho);
        }

        // GET: ThongKeKhoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongKeKho thongKeKho = db.ThongKeKhoes.Find(id);
            if (thongKeKho == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", thongKeKho.IdSach);
            return View(thongKeKho);
        }

        // POST: ThongKeKhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTKKho,NgayTK,SoLuongTon,IdSach")] ThongKeKho thongKeKho)
        {
            var entity = db.ThongKeKhoes.Find(thongKeKho.IdTKKho);
            if (entity == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                entity.NgayTK = thongKeKho.NgayTK;
                entity.SoLuongTon = thongKeKho.SoLuongTon;
                entity.IdSach = thongKeKho.IdSach;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSach = new SelectList(db.Saches, "IdSach", "TenSach", thongKeKho.IdSach);
            return View(thongKeKho);
        }

        // GET: ThongKeKhoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongKeKho thongKeKho = db.ThongKeKhoes.Find(id);
            if (thongKeKho == null)
            {
                return HttpNotFound();
            }
            return View(thongKeKho);
        }

        // POST: ThongKeKhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongKeKho thongKeKho = db.ThongKeKhoes.Find(id);
            db.ThongKeKhoes.Remove(thongKeKho);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
