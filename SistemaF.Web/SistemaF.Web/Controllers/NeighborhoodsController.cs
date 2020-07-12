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
    public class NeighborhoodsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Neighborhoods
        public ActionResult Index()
        {
            var neighborhood = db.Neighborhood.Include(n => n.City);
            return View(neighborhood.ToList());
        }

        // GET: Neighborhoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = db.Neighborhood.Find(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            return View(neighborhood);
        }

        // GET: Neighborhoods/Create
        public ActionResult Create()
        {
            ViewBag.City_Id = new SelectList(db.City, "City_Id", "City_Name");
            return View();
        }

        // POST: Neighborhoods/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Neighborhood_Id,Neighborhood_Name,City_Id")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                db.Neighborhood.Add(neighborhood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.City_Id = new SelectList(db.City, "City_Id", "City_Name", neighborhood.City_Id);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = db.Neighborhood.Find(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            ViewBag.City_Id = new SelectList(db.City, "City_Id", "City_Name", neighborhood.City_Id);
            return View(neighborhood);
        }

        // POST: Neighborhoods/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Neighborhood_Id,Neighborhood_Name,City_Id")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(neighborhood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.City_Id = new SelectList(db.City, "City_Id", "City_Name", neighborhood.City_Id);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = db.Neighborhood.Find(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            return View(neighborhood);
        }

        // POST: Neighborhoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Neighborhood neighborhood = db.Neighborhood.Find(id);
            db.Neighborhood.Remove(neighborhood);
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
