using Database.Dao;
using QLLDGV.Areas.Admin.Models;
using QLLDGV.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLLDGV.Controllers
{
    public class LoginGVController : Controller
    {
        // GET: LoginGV
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginGV(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var gv = new UserGV();
                var result = gv.Login(model.Email, model.Password);
                if (result)
                {
                    var user = gv.GetByEmail(model.Email);
                    var userSession = new UserLogin();
                    userSession.UserName = user.HoTenGV;
                    userSession.UserID = user.MaGV;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "HomeGV");
                }
                else
                {
                    @ViewBag.ThongBao = "Đăng nhập không thành công";
                }
            }
            return View("LoginGV");
        }
        public ActionResult LogoutGV()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("LoginGV", "LoginGV");

        }
    }
}