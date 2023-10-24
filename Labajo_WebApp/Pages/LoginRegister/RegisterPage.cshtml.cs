using Labajo_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labajo_WebApp.Pages.LoginRegister
{
    public class RegisterPageModel : PageModel
    {
     
        private readonly Labajo_WebApp.Data.Labajo_WebAppContext _context;

        public RegisterPageModel(Labajo_WebApp.Data.Labajo_WebAppContext context)
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
            ModelState.AddModelError("", "Successfully Registered");
            return RedirectToPage("../Index");
        }
    }
}
