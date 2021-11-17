using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubTournamentMVC;

namespace ClubTournamentMVC.Controllers
{
    public class ClubesController : Controller
    {
        private ClubTournamentEntities db = new ClubTournamentEntities();

        // GET: Clubes
        
        public ActionResult Index()
        {
            return View(db.Clubes.ToList());
        }

        // GET: Clubes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubes clubes = db.Clubes.Find(id);
            if (clubes == null)
            {
                return HttpNotFound();
            }
            return View(clubes);
        }

        // GET: Clubes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clubes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClub,Nombre,Dirección,Telefono,Geoubicacion,Dias_Laborales")] Clubes clubes)
        {
            if (ModelState.IsValid)
            {
                db.Clubes.Add(clubes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clubes);
        }

        // GET: Clubes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubes clubes = db.Clubes.Find(id);
            if (clubes == null)
            {
                return HttpNotFound();
            }
            return View(clubes);
        }

        // POST: Clubes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClub,Nombre,Dirección,Telefono,Geoubicacion,Dias_Laborales")] Clubes clubes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubes);
        }

        // GET: Clubes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubes clubes = db.Clubes.Find(id);
            if (clubes == null)
            {
                return HttpNotFound();
            }
            return View(clubes);
        }

        // POST: Clubes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clubes clubes = db.Clubes.Find(id);
            db.Clubes.Remove(clubes);
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
