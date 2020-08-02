using System;
using System.Web;
using WebKhoSachMVC.Models;

namespace WebKhoSachMVC
{
    public static class SessionExtensions
    {
        public static void SetUserSession(this HttpSessionStateBase session, User user)
        {
            if (session == null) throw new ArgumentNullException();
            if (user == null) throw new ArgumentNullException();

            session[SessionInfo.UserId] = user.IdUser.ToString();
            session[SessionInfo.UserName] = user.UserName.ToString();
            session[SessionInfo.QuyenTC] = user.QuyenTC;
        }

        public static string GetQuyenTc(this HttpSessionStateBase session)
        {
            if (session == null) throw new ArgumentNullException();
            return session[SessionInfo.QuyenTC] as string;
        }
    }
}