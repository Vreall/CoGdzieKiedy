using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        public ActionResult Home()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IEnumerable<Event> events = new List<Event>();
            events = context.Events;
            return View(events);
        }




        // GET: Events
        public ActionResult Index()
        {

          

            ApplicationDbContext context = new ApplicationDbContext();
            IEnumerable<Event> events = new List<Event>();
            events = context.Events;
            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
       
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NazwaWydarzenia,OpisWydarzenia,CenaBiletu,MiejsceWydarzenia,DataWydarzenia,GodzinaRozpoczeciaImprezy,ApplicationUserID")] Event @event)
        {
            
            if (ModelState.IsValid)
            {
                string userid = User.Identity.GetUserId();
               
                
                db.Events.Add(@event);

                 @event.ApplicationUserID=userid;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }


        // GET: Events/Create
        [Authorize(Roles = "Admin")]

        public ActionResult CreateAdmin()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateAdmin([Bind(Include = "ID,NazwaWydarzenia,OpisWydarzenia,CenaBiletu,MiejsceWydarzenia,DataWydarzenia,GodzinaRozpoczeciaImprezy,ApplicationUserID")] Event @event)
        {

            if (ModelState.IsValid)
            {
                string userid = User.Identity.GetUserId();


                db.Events.Add(@event);

                @event.ApplicationUserID = userid;

                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NazwaWydarzenia,OpisWydarzenia,CenaBiletu,MiejsceWydarzenia,DataWydarzenia,GodzinaRozpoczeciaImprezy,ApplicationUserID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
