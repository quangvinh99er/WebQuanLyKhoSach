using System;
using System.Web.Mvc;
using WebKhoSachMVC.Models;

namespace WebKhoSachMVC
{
    public static class SachExtensions
    {
        public static string GetImageOrDefault(this UrlHelper urlHelper, Sach sach)
        {
            if (sach == null) throw new ArgumentNullException();

            if (string.IsNullOrEmpty(sach.AnhSach1))
                return urlHelper.Content(AppPicture.DefaultImage);

            return urlHelper.Content(sach.AnhSach1);
        }

        public static string GetDefaultImage(this UrlHelper urlHelper)
        {
            return urlHelper.Content(AppPicture.DefaultImage);
        }
    }
}