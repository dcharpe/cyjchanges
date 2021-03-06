﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CYJ.Models;

namespace CYJ.Controllers
{
    [Authorize(Roles ="Admin, Observer")]
    public class ABOUTsController : Controller
    {
        private cyjEntities db = new cyjEntities();

        // GET: ABOUTs
        // GET: ABOUTs
        [Authorize(Roles = "Admin, Observer, Writer, Approver")]
        public ActionResult Index()
        {
            return View(db.ABOUTs.ToList());
        }
        [Authorize(Roles = "Admin, Observer, Writer, Approver")]
        public ActionResult Home()
        {
            return View(db.ABOUTs.ToList());
        }
        // GET: ABOUTs/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ABOUTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "aboutID,aboutInfo")] ABOUT aBOUT)
        {
            db.ABOUTs.Add(aBOUT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ABOUTs/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABOUT aBOUT = db.ABOUTs.Find(id);
            if (aBOUT == null)
            {
                return HttpNotFound();
            }
            return View(aBOUT);
        }

        // POST: ABOUTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "aboutID,aboutInfo")] ABOUT aBOUT)
        {
            db.Entry(aBOUT).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ABOUTs/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABOUT aBOUT = db.ABOUTs.Find(id);
            if (aBOUT == null)
            {
                return HttpNotFound();
            }
            return View(aBOUT);
        }

        // POST: ABOUTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ABOUT aBOUT = db.ABOUTs.Find(id);
            db.ABOUTs.Remove(aBOUT);
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
