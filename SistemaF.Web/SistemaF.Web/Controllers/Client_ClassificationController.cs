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
    public class Client_ClassificationController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Client_Classification
        public ActionResult Index()
        {
            return View(db.Client_Classification.ToList());
        }

        // GET: Client_Classification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Classification client_Classification = db.Client_Classification.Find(id);
            if (client_Classification == null)
            {
                return HttpNotFound();
            }
            return View(client_Classification);
        }

        // GET: Client_Classification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client_Classification/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientClass_Id,ClientClass_Name")] Client_Classification client_Classification)
        {
            if (ModelState.IsValid)
            {
                db.Client_Classification.Add(client_Classification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client_Classification);
        }

        // GET: Client_Classification/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Classification client_Classification = db.Client_Classification.Find(id);
            if (client_Classification == null)
            {
                return HttpNotFound();
            }
            return View(client_Classification);
        }

        // POST: Client_Classification/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientClass_Id,ClientClass_Name")] Client_Classification client_Classification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client_Classification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client_Classification);
        }

        // GET: Client_Classification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Classification client_Classification = db.Client_Classification.Find(id);
            if (client_Classification == null)
            {
                return HttpNotFound();
            }
            return View(client_Classification);
        }

        // POST: Client_Classification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client_Classification client_Classification = db.Client_Classification.Find(id);
            db.Client_Classification.Remove(client_Classification);
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
