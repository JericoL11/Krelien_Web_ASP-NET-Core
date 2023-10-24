using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Labajo_WebApp.Data;
using Labajo_WebApp.Models;

namespace Labajo_WebApp.Pages.CrudPages
{
    public class CreateModel : PageModel
    {
        private readonly Labajo_WebApp.Data.Labajo_WebAppContext _context;

        public CreateModel(Labajo_WebApp.Data.Labajo_WebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CrudModels CrudModels { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CrudModels == null || CrudModels == null)
            {
                return Page();
            }

            _context.CrudModels.Add(CrudModels);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
