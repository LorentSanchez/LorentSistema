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
    public class CompaniesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Companies
        public ActionResult Index()
        {
            var company = db.Company.Include(c => c.Company_Classification).Include(c => c.Document).Include(c => c.Neighborhood);
            return View(company.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.CompanyClass_Id = new SelectList(db.Company_Classification, "CompanyClass_Id", "CompanyClass_Name");
            ViewBag.Document_Id = new SelectList(db.Document, "Document_Id", "Documento");
            ViewBag.Neighborhood_Id = new SelectList(db.Neighborhood, "Neighborhood_Id", "Neighborhood_Name");
            return View();
        }

        // POST: Companies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Company_Id,Company_Name,CompanyClass_Id,Document_Id,Document_Code,Direccion,Neighborhood_Id,correo,phone")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Company.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyClass_Id = new SelectList(db.Company_Classification, "CompanyClass_Id", "CompanyClass_Name", company.CompanyClass_Id);
            ViewBag.Document_Id = new SelectList(db.Document, "Document_Id", "Documento", company.Document_Id);
            ViewBag.Neighborhood_Id = new SelectList(db.Neighborhood, "Neighborhood_Id", "Neighborhood_Name", company.Neighborhood_Id);
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyClass_Id = new SelectList(db.Company_Classification, "CompanyClass_Id", "CompanyClass_Name", company.CompanyClass_Id);
            ViewBag.Document_Id = new SelectList(db.Document, "Document_Id", "Documento", company.Document_Id);
            ViewBag.Neighborhood_Id = new SelectList(db.Neighborhood, "Neighborhood_Id", "Neighborhood_Name", company.Neighborhood_Id);
            return View(company);
        }

        // POST: Companies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Company_Id,Company_Name,CompanyClass_Id,Document_Id,Document_Code,Direccion,Neighborhood_Id,correo,phone")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyClass_Id = new SelectList(db.Company_Classification, "CompanyClass_Id", "CompanyClass_Name", company.CompanyClass_Id);
            ViewBag.Document_Id = new SelectList(db.Document, "Document_Id", "Documento", company.Document_Id);
            ViewBag.Neighborhood_Id = new SelectList(db.Neighborhood, "Neighborhood_Id", "Neighborhood_Name", company.Neighborhood_Id);
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Company.Find(id);
            db.Company.Remove(company);
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
