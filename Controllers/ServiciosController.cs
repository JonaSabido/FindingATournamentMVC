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
    public class ServiciosController : Controller
    {
        private ClubTournamentEntities db = new ClubTournamentEntities();

        // GET: Servicios
        public ActionResult Index()
        {
            var servicios = db.Servicios.Include(s => s.Clubes).Include(s => s.Discipline);
            return View(servicios.ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.Clubes, "idClub", "Nombre");
            ViewBag.DisciplineId = new SelectList(db.Discipline, "idDiscipline", "Nombre");
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idService,Nombre,Num_Personas,EquipoEspecial,EquipoEspecialDescripction,PersonasDiscapacitadas,ClubId,DisciplineId")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Servicios.Add(servicios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.Clubes, "idClub", "Nombre", servicios.ClubId);
            ViewBag.DisciplineId = new SelectList(db.Discipline, "idDiscipline", "Nombre", servicios.DisciplineId);
            return View(servicios);
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.Clubes, "idClub", "Nombre", servicios.ClubId);
            ViewBag.DisciplineId = new SelectList(db.Discipline, "idDiscipline", "Nombre", servicios.DisciplineId);
            return View(servicios);
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idService,Nombre,Num_Personas,EquipoEspecial,EquipoEspecialDescripction,PersonasDiscapacitadas,ClubId,DisciplineId")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.Clubes, "idClub", "Nombre", servicios.ClubId);
            ViewBag.DisciplineId = new SelectList(db.Discipline, "idDiscipline", "Nombre", servicios.DisciplineId);
            return View(servicios);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicios servicios = db.Servicios.Find(id);
            db.Servicios.Remove(servicios);
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
