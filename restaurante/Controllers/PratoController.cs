using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantSystem.Models.ViewModel;

namespace RestaurantSystem.Controllers
{
    public class PratoController : Controller
    {
        private TesteEntities db = new TesteEntities();

        // GET: Prato
        public ActionResult Index(int id)
        {
            var prato = db.Prato.Include(p => p.Restaurante).Include(p => p.Restaurante1);
            //int id = prato.First().restId;
            var prat = db.Prato.SqlQuery("select * from dbo.Prato p where p.restId = @p0", id).ToList();
            //return View(prato.ToList());
            return View(prat);
        }

        // GET: Prato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Prato.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // GET: Prato/Create
        public ActionResult Create()
        {
            ViewBag.restId = new SelectList(db.Restaurante, "restId", "restName");
            ViewBag.restId = new SelectList(db.Restaurante, "restId", "restName");
            return View();
        }

        // POST: Prato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pratoId,restId,pratoName,pratoPreco")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Prato.Add(prato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.restId = new SelectList(db.Restaurante, "restId", "restName", prato.restId);
            ViewBag.restId = new SelectList(db.Restaurante, "restId", "restName", prato.restId);
            return View(prato);
        }

        // GET: Prato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Prato.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            ViewBag.restId = new SelectList(db.Restaurante, "restId", "restName", prato.restId);
            ViewBag.restId = new SelectList(db.Restaurante, "restId", "restName", prato.restId);
            return View(prato);
        }

        // POST: Prato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pratoId,restId,pratoName,pratoPreco")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.restId = new SelectList(db.Restaurante, "restId", "restName", prato.restId);
            ViewBag.restId = new SelectList(db.Restaurante, "restId", "restName", prato.restId);
            return View(prato);
        }

        // GET: Prato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Prato.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // POST: Prato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prato prato = db.Prato.Find(id);
            db.Prato.Remove(prato);
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
