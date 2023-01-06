﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database.Framework;
using PagedList;

namespace QLLDGV.Areas.Admin.Controllers
{
    public class HocPhansController : BaseController
    {
        private UserDbContext db = new UserDbContext();

        // GET: Admin/HocPhans
        public ActionResult Index(int? page, string SearchString, string currentFilter)
        {
            var links = new List<HocPhan>();
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
                links = db.HocPhans.Where(n => n.MonHoc1.TenMH.Contains(SearchString) ||
                                            n.TenNhom.Contains(SearchString)).ToList();
            }
            else
            {
                links = db.HocPhans.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            links = links.OrderByDescending(n => n.MonHoc1.TenMH).ToList();
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/HocPhans/Create
        public ActionResult Create()
        {
            ViewBag.MonHoc = new SelectList(db.MonHocs, "MaMH", "TenMH");
            return View();
        }

        // POST: Admin/HocPhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhom,MonHoc,TenNhom")] HocPhan hocPhan)
        {
            if (ModelState.IsValid)
            {
                hocPhan.MaNhom = Guid.NewGuid();
                db.HocPhans.Add(hocPhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MonHoc = new SelectList(db.MonHocs, "MaMH", "TenMH", hocPhan.MonHoc);
            return View(hocPhan);
        }

        // GET: Admin/HocPhans/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhan hocPhan = db.HocPhans.Find(id);
            if (hocPhan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MonHoc = new SelectList(db.MonHocs, "MaMH", "TenMH", hocPhan.MonHoc);
            return View(hocPhan);
        }

        // POST: Admin/HocPhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhom,MonHoc,TenNhom")] HocPhan hocPhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocPhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MonHoc = new SelectList(db.MonHocs, "MaMH", "TenMH", hocPhan.MonHoc);
            return View(hocPhan);
        }

        // GET: Admin/HocPhans/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhan hocPhan = db.HocPhans.Find(id);
            if (hocPhan == null)
            {
                return HttpNotFound();
            }
            return View(hocPhan);
        }

        // POST: Admin/HocPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            HocPhan hocPhan = db.HocPhans.Find(id);
            db.HocPhans.Remove(hocPhan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
