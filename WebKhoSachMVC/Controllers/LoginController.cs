using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebKhoSachMVC.Models;
using WebKhoSachMVC.Mvc;

namespace WebKhoSachMVC.Controllers
{
    public class LoginController : Controller
    {
        private KhoSachEntities db;
        public LoginController(KhoSachEntities context)
        {
            db = context;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User objk, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                using (KhoSachEntities db = new KhoSachEntities())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(objk.UserName) && a.PassWord.Equals(objk.PassWord)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session.SetUserSession(obj);
                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            return RedirectToAction("Index", "Home");
                        } else
                        {
                            //*unsafe*
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("","The UserName or PassWord Incorrect");
                    }

                }
            }

            return View(objk);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");

        }
    }
}