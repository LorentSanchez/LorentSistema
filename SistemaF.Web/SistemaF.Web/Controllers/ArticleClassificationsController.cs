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
    public class ArticleClassificationsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ArticleClassifications
        public ActionResult Index()
        {
            return View(db.ArticleClassification.ToList());
        }

        // GET: ArticleClassifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleClassification articleClassification = db.ArticleClassification.Find(id);
            if (articleClassification == null)
            {
                return HttpNotFound();
            }
            return View(articleClassification);
        }

        // GET: ArticleClassifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleClassifications/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtC_Id,Codigo,Name_ArtC")] ArticleClassification articleClassification)
        {
            if (ModelState.IsValid)
            {
                db.ArticleClassification.Add(articleClassification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articleClassification);
        }

        // GET: ArticleClassifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleClassification articleClassification = db.ArticleClassification.Find(id);
            if (articleClassification == null)
            {
                return HttpNotFound();
            }
            return View(articleClassification);
        }

        // POST: ArticleClassifications/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtC_Id,Codigo,Name_ArtC")] ArticleClassification articleClassification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleClassification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articleClassification);
        }

        // GET: ArticleClassifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleClassification articleClassification = db.ArticleClassification.Find(id);
            if (articleClassification == null)
            {
                return HttpNotFound();
            }
            return View(articleClassification);
        }

        // POST: ArticleClassifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleClassification articleClassification = db.ArticleClassification.Find(id);
            db.ArticleClassification.Remove(articleClassification);
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
