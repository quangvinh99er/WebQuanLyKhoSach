using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebKhoSachMVC.Models;
using WebKhoSachMVC.Mvc;

namespace WebKhoSachMVC.Controllers
{
    [QuyenTk(Quyen.NhanVien)]
    public class SachesController : Controller
    {
        private KhoSachEntities db;

        public SachesController(KhoSachEntities context)
        {
            db = context;
        }
        // GET: Saches
        public ActionResult Index(string searchString)
        {
            var links = from l in db.Saches
                        select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.TenSach.Contains(searchString));
            }

            return View(links);
        }

        // GET: Saches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Saches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSach,TenSach,GiaThanh,NhaXuatBan,TacGia,NamXB,Soluongphathanh")] Sach sach, HttpPostedFileBase anhSach1)
        {
            if (ModelState.IsValid)
            {
                if (anhSach1 != null)
                {
                    sach.AnhSach1 = SavePicture(anhSach1);
                }
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sach);
        }

        private string SavePicture(HttpPostedFileBase uploadedPicture)
        {
            var fileName = Path.GetFileNameWithoutExtension(uploadedPicture.FileName);
            var extension = Path.GetExtension(uploadedPicture.FileName);
            var pictureFileName = $"{fileName}_{new Guid()}{extension}";
            var picturePath = Path.Combine(Server.MapPath(AppPicture.ImageStorage), pictureFileName);
            if (System.IO.File.Exists(picturePath))
            {
                System.IO.File.Delete(picturePath);
            }
            uploadedPicture.SaveAs(picturePath);
            return $"~/Content/img/{fileName}{extension}";
        }

        // GET: Saches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSach,TenSach,GiaThanh,NhaXuatBan,TacGia,NamXB,Soluongphathanh")] Sach sach, HttpPostedFileBase anhSach1)
        {
            var entity = db.Saches.Find(sach.IdSach);
            if (entity == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                if(anhSach1 != null)
                {
                    //delete old picture
                    if (!string.IsNullOrEmpty(entity.AnhSach1))
                    {
                        //get on server file path
                        var serverFilePath = Server.MapPath(entity.AnhSach1);
                        if (System.IO.File.Exists(serverFilePath))
                        {
                            System.IO.File.Delete(serverFilePath);
                        }
                    }
                    entity.AnhSach1 = SavePicture(anhSach1);
                }
                entity.TenSach = sach.TenSach;
                entity.GiaThanh = sach.GiaThanh;
                entity.NhaXuatBan = sach.NhaXuatBan;
                entity.TacGia = sach.TacGia;
                entity.Soluongphathanh = sach.Soluongphathanh;
                entity.NamXB = sach.NamXB;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sach);
        }

        // GET: Saches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
