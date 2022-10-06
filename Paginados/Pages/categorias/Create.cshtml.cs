using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Curso.Domains.Entities;
using Curso.Infraestructure.UoW;

namespace Paginados.Pages.categorias
{
    public class CreateModel : PageModel
    {
        private readonly Curso.Infraestructure.UoW.TiendaDBContext _context;

        public CreateModel(Curso.Infraestructure.UoW.TiendaDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ParentProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "Name");
            return Page();
        }

        [BindProperty]
        public ProductCategory ProductCategory { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductCategories.Add(ProductCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
