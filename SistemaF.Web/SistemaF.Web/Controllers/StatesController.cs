using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema.Web.Data;
using Sistema.Web.Data.Entities;

namespace SistemaF.Web.Controllers
{
    public class StatesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: States
        public ActionResult Index()
        {
            var state = db.State.Include(s => s.Country);
            return View(state.ToList());
        }

        // GET: States/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // GET: States/Create
        public ActionResult Create()
        {
            ViewBag.Country_Id = new SelectList(db.Country, "Country_Id", "Country_Name");
            return View();
        }

        // POST: States/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "State_Id,State_Name,Country_Id")] State state)
        {
            if (ModelState.IsValid)
            {
                db.State.Add(state);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country_Id = new SelectList(db.Country, "Country_Id", "Country_Name", state.Country_Id);
            return View(state);
        }

        // GET: States/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            ViewBag.Country_Id = new SelectList(db.Country, "Country_Id", "Country_Name", state.Country_Id);
            return View(state);
        }

        // POST: States/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "State_Id,State_Name,Country_Id")] State state)
        {
            if (ModelState.IsValid)
            {
                db.Entry(state).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country_Id = new SelectList(db.Country, "Country_Id", "Country_Name", state.Country_Id);
            return View(state);
        }

        // GET: States/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            State state = db.State.Find(id);
            db.State.Remove(state);
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
