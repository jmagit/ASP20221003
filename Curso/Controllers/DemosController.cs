using Curso.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Controllers {
    [Route("/ejemplos/del/curso")]
    public class DemosController : Controller {
        // GET: DemosController
        [Route("")]
        [Route("Index")]
        public ActionResult Index() {
            var list = new List<Persona>();
            list.Add(new Persona() { IdPersona = 1, Nombre = "Pepito", Apellidos = "Grillo", Edad = 99 });
            list.Add(new Persona() { IdPersona = 2, Nombre = "Carmelo", Apellidos = "Coton<script>alert('codigo malicioso')</script>", Edad = 23 });
            ViewData["Listado"] = list;
            return View();
        }

        public string Reports(int year, int mouth) {
            return $"Informe {mouth}/{year}";
        }

        // GET: DemosController/Details/5
        public ActionResult Details(int id) {
            return View(new Persona() { IdPersona = 1, Nombre = "Pepito", Apellidos = "Grillo", Edad = 99 });
        }

        // GET: DemosController/Create
        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        // POST: DemosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: DemosController/Edit/5
        public ActionResult Edit(int id) {
            return View(new Persona() { IdPersona = 1, Nombre = "Pepito", Apellidos = "Grillo", Edad = 99 });
        }

        // POST: DemosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: DemosController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: DemosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}
