using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Labajo_WebApp.Data;
using Labajo_WebApp.Models;

namespace Labajo_WebApp.Pages.CrudPages
{
    public class DeleteModel : PageModel
    {
        private readonly Labajo_WebApp.Data.Labajo_WebAppContext _context;

        public DeleteModel(Labajo_WebApp.Data.Labajo_WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CrudModels CrudModels { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CrudModels == null)
            {
                return NotFound();
            }

            var crudmodels = await _context.CrudModels.FirstOrDefaultAsync(m => m.id == id);

            if (crudmodels == null)
            {
                return NotFound();
            }
            else 
            {
                CrudModels = crudmodels;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CrudModels == null)
            {
                return NotFound();
            }
            var crudmodels = await _context.CrudModels.FindAsync(id);

            if (crudmodels != null)
            {
                CrudModels = crudmodels;
                _context.CrudModels.Remove(CrudModels);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
