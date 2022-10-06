using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Curso.Domains.Entities;
using Curso.Infraestructure.UoW;
using System.Drawing;
using Curso.Domains.Contracts.Services;

namespace Curso.Controllers {
    public class ProductsController : Controller {
        private readonly TiendaDBContext _context;
        private readonly IProductService srv;

        public ProductsController(TiendaDBContext context, IProductService srv) {
            _context = context;
            this.srv = srv;
        }

        // GET: Products
        //public async Task<IActionResult> Index() {
        //    var tiendaDBContext = _context.Products.Include(p => p.ProductCategory).Include(p => p.ProductModel);
        //    return View(await tiendaDBContext.ToListAsync());
        //}
        public IActionResult Index() {
            return View(srv.GetAll());
        }
        public IActionResult Listado(int num=0, int rows=15) {
            var tiendaDBContext = _context.Products.Skip(num * rows).Take(rows).Include(p => p.ProductCategory).Include(p => p.ProductModel);
            ViewBag.Paginas = (int)Math.Ceiling((decimal)_context.Products.Count() / rows);
            ViewBag.Pagina = num;
            ViewBag.Filas = rows;
            this.Response.Headers.Add("x-curso", "ASP.NET");

            return View(tiendaDBContext.ToList());
        }

        public IActionResult Ajax(int num = 0, int rows = 15) {
            var tiendaDBContext = _context.Products.Skip(num * rows).Take(rows).Include(p => p.ProductCategory).Include(p => p.ProductModel);
            ViewBag.Paginas = (int)Math.Ceiling((decimal)_context.Products.Count() / rows);
            ViewBag.Pagina = num;
            ViewBag.Filas = rows;
            this.Response.Headers.Add("x-curso", "ASP.NET");

            return View(tiendaDBContext.ToList());
        }

        public IActionResult Fragmento(int num = 0, int rows = 15) {
            var tiendaDBContext = _context.Products.Skip(num * rows).Take(rows).Include(p => p.ProductCategory).Include(p => p.ProductModel);

            return PartialView("_tbody", tiendaDBContext.ToList());
        }


        public IActionResult FragmentoJson(int num = 0, int rows = 15) {
            var tiendaDBContext = _context.Products.Skip(num * rows).Take(rows)
                .Select(p => new { p.ProductId, p.ProductNumber, p.Name });

            return Json(tiendaDBContext.ToList());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id) {
            if(id == null || _context.Products == null) {
                // this.StatusCode(404)
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if(product == null) {
                return NotFound();
            }

            return View(product);
        }
        public async Task<IActionResult> Photo(int? id) {
            if(id == null || _context.Products == null) {
                // this.StatusCode(404)
                return NotFound();
            }

            var product = await _context.Products.Where(m => m.ProductId == id).Select(p => p.ThumbNailPhoto).FirstOrDefaultAsync();
            if(product == null) {
                return NotFound();
            }

            return File(product, "image/gif");
        }
        public async Task<IActionResult> Datos(int? id) {
            if(id == null || _context.Products == null) {
                // this.StatusCode(404)
                return BadRequest();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            if(product == null) {
                return NotFound();
            }

            return Json(product);
        }

        // GET: Products/Create
        public IActionResult Create() {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "Name");
            ViewBag.ProductModelId = new SelectList(_context.ProductModels, "ProductModelId", "Name");
            return View("Edit");
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product) {
            if(ModelState.IsValid) {
                try {
                    if(product.IsInvalid) {
                        return BadRequest();
                    } else {
                        _context.Add(product);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                } catch(Exception ex) {
                        ModelState.AddModelError("", ex.Message);

                }
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "Name", product.ProductCategoryId);
            ViewData["ProductModelId"] = new SelectList(_context.ProductModels, "ProductModelId", "Name", product.ProductModelId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if(id == null || _context.Products == null) {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if(product == null) {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "Name", product.ProductCategoryId);
            ViewData["ProductModelId"] = new SelectList(_context.ProductModels, "ProductModelId", "Name", product.ProductModelId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,ProductNumber,Color,StandardCost,ListPrice,Size,Weight,ProductCategoryId,ProductModelId,SellStartDate,SellEndDate,DiscontinuedDate,ThumbNailPhoto,ThumbnailPhotoFileName,Rowguid,ModifiedDate")] Product product) {
            if(id != product.ProductId) {
                return NotFound();
            }

            if(ModelState.IsValid) {
                try {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                } catch(DbUpdateConcurrencyException) {
                    if(!ProductExists(product.ProductId)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "Name", product.ProductCategoryId);
            ViewData["ProductModelId"] = new SelectList(_context.ProductModels, "ProductModelId", "Name", product.ProductModelId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if(id == null || _context.Products == null) {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if(product == null) {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if(_context.Products == null) {
                return Problem("Entity set 'TiendaDBContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if(product != null) {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private bool ProductExists(int id) {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
