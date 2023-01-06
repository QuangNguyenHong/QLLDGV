using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Database.Framework;

namespace QLLDGV.Areas.Admin.Controllers
{
    public class ForgetPasswordAdminController : Controller
    {
        private UserDbContext db = new UserDbContext();
        // GET: Admin/ForgetPasswordAdmin
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(MailModel _objModelMail)
        {
            String pass = "abcdefghijklmnopqrstuvwxyz1234567890";
            Random r = new Random();
            char[] mypass = new char[5];
            for (int i = 0; i < 5; i++)
            {
                mypass[i] = pass[(int)(35 * r.NextDouble())];
            }
            string mkm = new string(mypass);
            MailMessage mail = new MailMessage();
            mail.To.Add(_objModelMail.To);
            mail.From = new MailAddress("testaspmvc123@gmail.com", "Admin");
            mail.Subject = "Nhận lại mật khẩu";
            string Body = "<h4><b>Mật khẩu mới của bạn là: " + mkm + "</b></h4>";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("testaspmvc123@gmail.com", "qkovstsfttgohtgl"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            var checkmail = db.QuanTris.Count(x => x.Email == _objModelMail.To);
            if (checkmail > 0)
            {
                QuanTri qt = db.QuanTris.SingleOrDefault(x => x.Email == _objModelMail.To);
                qt.MatKhau = mkm;
                db.SaveChanges();
                smtp.Send(mail);
                @ViewBag.ThongBao = "Gửi thành công vui lòng check Mail!";
            }
            else
            {
                @ViewBag.ThongBao = "Email không tồn tại";
            }
            return View("ForgotPassword");
        }
    }
}