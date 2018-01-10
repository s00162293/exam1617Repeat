using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using examRepeat1617.Models;
using examRepeat1617.Models.Data;

namespace examRepeat1617.Controllers
{
    public class Attendances1Controller : Controller
    {
        private AttendDBContext db = new AttendDBContext();

        // GET: Attendances1
        public ActionResult Index()
        {
            var attendance = db.attendance.Include(a => a.associatedStudent).Include(a => a.associatedSubject);
            return View(attendance.ToList());
        }

        // GET: Attendances1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendances1/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "FirstName");
            ViewBag.SubjectId = new SelectList(db.subjects, "SubjectId", "SubjectId");
            return View();
        }

        // POST: Attendances1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttendanceId,AttendanceDate,Present,StudentId,SubjectId")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.attendance.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.students, "StudentId", "FirstName", attendance.StudentId);
            ViewBag.SubjectId = new SelectList(db.subjects, "SubjectId", "SubjectId", attendance.SubjectId);
            return View(attendance);
        }

        // GET: Attendances1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "FirstName", attendance.StudentId);
            ViewBag.SubjectId = new SelectList(db.subjects, "SubjectId", "SubjectId", attendance.SubjectId);
            return View(attendance);
        }

        // POST: Attendances1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendanceId,AttendanceDate,Present,StudentId,SubjectId")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "FirstName", attendance.StudentId);
            ViewBag.SubjectId = new SelectList(db.subjects, "SubjectId", "SubjectId", attendance.SubjectId);
            return View(attendance);
        }

        // GET: Attendances1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.attendance.Find(id);
            db.attendance.Remove(attendance);
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
