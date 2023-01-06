using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Database.Framework;
using Microsoft.Ajax.Utilities;
using PagedList;

namespace QLLDGV.Controllers
{
    public class LichDayGVController : BaseGVController
    {
        private UserDbContext db = new UserDbContext();

        // GET: LichDayGV
        public ActionResult Index(int? page, string SearchString, string currentFilter)
        {
            var session = (UserLogin)Session[QLLDGV.Common.CommonConstants.USER_SESSION];
            var links = new List<LichDay>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                links = db.LichDays.Where(n => n.GVDay == session.UserID &&
                                            n.MonHoc.TenMH.Contains(SearchString) ||
                                            n.HocPhan.TenNhom.Contains(SearchString) ||
                                            n.THU.TenThu.Contains(SearchString) ||
                                            n.PHONG.TenPhong.Contains(SearchString)).ToList();
            }
            else
            {
                links = db.LichDays.Where(n => n.GVDay == session.UserID).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            links = links.OrderByDescending(n => n.MonHoc.TenMH).ToList();
            return View(links.ToPagedList(pageNumber, pageSize));
        }
        public JsonResult GetEvents()
        {
            using (UserDbContext dc = new UserDbContext())
            {
                var session = (UserLogin)Session[QLLDGV.Common.CommonConstants.USER_SESSION];
                var events = dc.LichDays.Where(n => n.GVDay == session.UserID).ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        // GET: LichDayGV/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichDay lichDay = db.LichDays.Find(id);
            if (lichDay == null)
            {
                return HttpNotFound();
            }
            return View(lichDay);
        }
    }
}
