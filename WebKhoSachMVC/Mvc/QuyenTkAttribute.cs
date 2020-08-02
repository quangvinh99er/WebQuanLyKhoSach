using System;
using System.Web.Mvc;

namespace WebKhoSachMVC.Mvc
{
    public class QuyenTkAttribute : FilterAttribute, IAuthorizationFilter
    {
        private readonly string _quyenYeuCau;

        public QuyenTkAttribute(string quyenYeuCau)
        {
            _quyenYeuCau = quyenYeuCau;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null) return;
            if (string.IsNullOrEmpty(_quyenYeuCau)) return;
            if (filterContext.Result != null) return;

            var quyenTc = filterContext.HttpContext.Session.GetQuyenTc();

            if (string.IsNullOrEmpty(quyenTc))
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }
            var roles = quyenTc.Split(',');
            if (roles.Length == 0)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }
            foreach (var role in roles)
            {
                if (string.Equals(_quyenYeuCau, role.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}