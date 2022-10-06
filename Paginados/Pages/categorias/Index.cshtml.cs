using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Curso.Domains.Entities;
using Curso.Infraestructure.UoW;

namespace Paginados.Pages.categorias {
    public class IndexModel : PageModel {
        private readonly Curso.Infraestructure.UoW.TiendaDBContext _context;

        public IndexModel(Curso.Infraestructure.UoW.TiendaDBContext context) {
            _context = context;
        }

        [ViewData]
        public int paginas { get; set; }

        public IList<ProductCategory> ProductCategory { get; set; } = default!;

        public async Task OnGetAsync() {
            paginas = 10;
            if(_context.ProductCategories != null) {
                ProductCategory = await _context.ProductCategories
                .Include(p => p.ParentProductCategory).ToListAsync();
            }
        }
    }
}
