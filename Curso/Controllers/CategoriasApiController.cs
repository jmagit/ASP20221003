using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Curso.Domains.Entities;
using Curso.Infraestructure.UoW;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Curso.Controllers;

public class CategoriaDto {
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Nombre { get; set; }
}

[Route("api/categorias")]
[ApiController]
public class CategoriasApiController : ControllerBase {
    private readonly TiendaDBContext _context;

    public CategoriasApiController(TiendaDBContext context) {
        _context = context;
    }

    // GET: api/CategoriasApi
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetProductCategories() {
        return await _context.ProductCategories.Where(o => o.ParentProductCategory == null)
            .Select(o => new CategoriaDto() { Id = o.ProductCategoryId, Nombre = o.Name }).ToListAsync();
    }

    // GET: api/CategoriasApi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductCategory>> GetProductCategory(int id) {
        var productCategory = await _context.ProductCategories.FindAsync(id);

        if(productCategory == null) {
            return NotFound();
        }

        return productCategory;
    }
    // GET: api/CategoriasApi/5
    [HttpGet("{id}/subcategorias")]
    public ActionResult<IEnumerable<CategoriaDto>> GetSubcategorias(int id) {
        var productCategory = _context.ProductCategories.Where(o => o.ProductCategoryId == id).Select(o => o.InverseParentProductCategory).FirstOrDefault();

        if(productCategory == null) {
            return NotFound();
        }

        return productCategory.Select(o => new CategoriaDto() { Id = o.ProductCategoryId, Nombre = o.Name }).ToList();
    }

    // PUT: api/CategoriasApi/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductCategory(int id, ProductCategory productCategory) {
        if(id != productCategory.ProductCategoryId) {
            return BadRequest();
        }

        _context.Entry(productCategory).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        } catch(DbUpdateConcurrencyException) {
            if(!ProductCategoryExists(id)) {
                return NotFound();
            } else {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/CategoriasApi
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory) {
        _context.ProductCategories.Add(productCategory);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductCategory), new { id = productCategory.ProductCategoryId }, productCategory);
    }

    // DELETE: api/CategoriasApi/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductCategory(int id) {
        var productCategory = await _context.ProductCategories.FindAsync(id);
        if(productCategory == null) {
            return NotFound();
        }

        _context.ProductCategories.Remove(productCategory);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductCategoryExists(int id) {
        return _context.ProductCategories.Any(e => e.ProductCategoryId == id);
    }
}

