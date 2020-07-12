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
    public class FormPagoesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: FormPagoes
        public ActionResult Index()
        {
            var formPago = db.FormPago.Include(f => f.Moneda);
            return View(formPago.ToList());
        }

        // GET: FormPagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormPago formPago = db.FormPago.Find(id);
            if (formPago == null)
            {
                return HttpNotFound();
            }
            return View(formPago);
        }

        // GET: FormPagoes/Create
        public ActionResult Create()
        {
            ViewBag.Moneda_Id = new SelectList(db.Moneda, "Moneda_Id", "Name_moneda");
            return View();
        }

        // POST: FormPagoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Pago,pago_Name,Moneda_Id")] FormPago formPago)
        {
            if (ModelState.IsValid)
            {
                db.FormPago.Add(formPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Moneda_Id = new SelectList(db.Moneda, "Moneda_Id", "Name_moneda", formPago.Moneda_Id);
            return View(formPago);
        }

        // GET: FormPagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormPago formPago = db.FormPago.Find(id);
            if (formPago == null)
            {
                return HttpNotFound();
            }
            ViewBag.Moneda_Id = new SelectList(db.Moneda, "Moneda_Id", "Name_moneda", formPago.Moneda_Id);
            return View(formPago);
        }

        // POST: FormPagoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Pago,pago_Name,Moneda_Id")] FormPago formPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Moneda_Id = new SelectList(db.Moneda, "Moneda_Id", "Name_moneda", formPago.Moneda_Id);
            return View(formPago);
        }

        // GET: FormPagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormPago formPago = db.FormPago.Find(id);
            if (formPago == null)
            {
                return HttpNotFound();
            }
            return View(formPago);
        }

        // POST: FormPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormPago formPago = db.FormPago.Find(id);
            db.FormPago.Remove(formPago);
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
