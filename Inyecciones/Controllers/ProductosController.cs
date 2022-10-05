using Curso.Domains.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inyecciones.Controllers {
    public class ProductosController : Controller {
        private readonly IProductService srv;

        public ProductosController(IProductService srv) {
            this.srv = srv;
        }

        // GET: ProductosController
        public ActionResult Index() {
            return View(srv.GetAll());
        }

        // GET: ProductosController/Details/5
        public ActionResult Details(int id) {
            return View(srv.GetOne(id));
        }

        // GET: ProductosController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: ProductosController/Delete/5
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
