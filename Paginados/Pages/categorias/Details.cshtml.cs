using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Curso.Domains.Entities;
using Curso.Infraestructure.UoW;

namespace Paginados.Pages.categorias
{
    public class DetailsModel : PageModel
    {
        private readonly Curso.Infraestructure.UoW.TiendaDBContext _context;

        public DetailsModel(Curso.Infraestructure.UoW.TiendaDBContext context)
        {
            _context = context;
        }

      public ProductCategory ProductCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductCategories == null)
            {
                return NotFound();
            }

            var productcategory = await _context.ProductCategories.FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (productcategory == null)
            {
                return NotFound();
            }
            else 
            {
                ProductCategory = productcategory;
            }
            return Page();
        }
    }
}
