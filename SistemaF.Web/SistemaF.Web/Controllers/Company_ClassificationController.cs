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
    public class Company_ClassificationController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Company_Classification
        public ActionResult Index()
        {
            return View(db.Company_Classification.ToList());
        }

        // GET: Company_Classification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Classification company_Classification = db.Company_Classification.Find(id);
            if (company_Classification == null)
            {
                return HttpNotFound();
            }
            return View(company_Classification);
        }

        // GET: Company_Classification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company_Classification/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyClass_Id,CompanyClass_Name")] Company_Classification company_Classification)
        {
            if (ModelState.IsValid)
            {
                db.Company_Classification.Add(company_Classification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company_Classification);
        }

        // GET: Company_Classification/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Classification company_Classification = db.Company_Classification.Find(id);
            if (company_Classification == null)
            {
                return HttpNotFound();
            }
            return View(company_Classification);
        }

        // POST: Company_Classification/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyClass_Id,CompanyClass_Name")] Company_Classification company_Classification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Classification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company_Classification);
        }

        // GET: Company_Classification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Classification company_Classification = db.Company_Classification.Find(id);
            if (company_Classification == null)
            {
                return HttpNotFound();
            }
            return View(company_Classification);
        }

        // POST: Company_Classification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company_Classification company_Classification = db.Company_Classification.Find(id);
            db.Company_Classification.Remove(company_Classification);
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
