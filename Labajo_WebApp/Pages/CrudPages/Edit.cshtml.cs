using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labajo_WebApp.Data;
using Labajo_WebApp.Models;

namespace Labajo_WebApp.Pages.CrudPages
{
    public class EditModel : PageModel
    {
        private readonly Labajo_WebApp.Data.Labajo_WebAppContext _context;

        public EditModel(Labajo_WebApp.Data.Labajo_WebAppContext context)
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

            var crudmodels =  await _context.CrudModels.FirstOrDefaultAsync(m => m.id == id);
            if (crudmodels == null)
            {
                return NotFound();
            }
            CrudModels = crudmodels;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CrudModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrudModelsExists(CrudModels.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CrudModelsExists(int id)
        {
          return (_context.CrudModels?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
