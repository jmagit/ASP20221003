using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Controllers {
    public class DemosController : Controller {
        // GET: DemosController
        public ActionResult Index() {
            return View();
        }

        // GET: DemosController/Details/5
        public ActionResult Details(int id) {
            return View();
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
            return View();
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
