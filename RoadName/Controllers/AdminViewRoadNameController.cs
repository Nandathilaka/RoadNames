using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoadName.Models;
using Microsoft.AspNet.Identity;

namespace RoadName.Controllers
{
    public class AdminViewRoadNameController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminViewRoadName
        public ActionResult Index()
        {
            var roadnames = db.Roadnames.Include(r => r.user);
            return View(roadnames.ToList());
        }

        // GET: AdminViewRoadName/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roadname roadname = db.Roadnames.Find(id);
            if (roadname == null)
            {
                return HttpNotFound();
            }
            return View(roadname);
        }

        // GET: AdminViewRoadName/Create
        public ActionResult Create()
        {
            var UserId = User.Identity.GetUserId();
            var CurrentUserID = db.Users.Where(e => e.Id == UserId);
            ViewBag.ApplicationUserId = new SelectList(CurrentUserID, "Id", "FirstName");
            return View();
        }

        // POST: AdminViewRoadName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplicationUserId,NameOfRoad,District,City,Location,VIPName,Story")] Roadname roadname)
        {
            if (ModelState.IsValid)
            {
                db.Roadnames.Add(roadname);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var UserId = User.Identity.GetUserId();
            var CurrentUserID = db.Users.Where(e => e.Id == UserId);
            ViewBag.ApplicationUserId = new SelectList(CurrentUserID, "Id", "FirstName", roadname.ApplicationUserId);
            return View(roadname);
        }

        // GET: AdminViewRoadName/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roadname roadname = db.Roadnames.Find(id);
            if (roadname == null)
            {
                return HttpNotFound();
            }

            var UserId = User.Identity.GetUserId();
            var CurrentUserID = db.Users.Where(e => e.Id == UserId);
            ViewBag.ApplicationUserId = new SelectList(CurrentUserID, "Id", "FirstName", roadname.ApplicationUserId);
            return View(roadname);
        }

        // POST: AdminViewRoadName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApplicationUserId,NameOfRoad,District,City,Location,VIPName,Story")] Roadname roadname)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roadname).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var UserId = User.Identity.GetUserId();
            var CurrentUserID = db.Users.Where(e => e.Id == UserId);
            ViewBag.ApplicationUserId = new SelectList(CurrentUserID, "Id", "FirstName", roadname.ApplicationUserId);
            return View(roadname);
        }

        // GET: AdminViewRoadName/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roadname roadname = db.Roadnames.Find(id);
            if (roadname == null)
            {
                return HttpNotFound();
            }
            return View(roadname);
        }

        // POST: AdminViewRoadName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roadname roadname = db.Roadnames.Find(id);
            db.Roadnames.Remove(roadname);
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
