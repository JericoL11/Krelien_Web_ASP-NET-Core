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
    public class IndexModel : PageModel
    {
        private readonly Labajo_WebApp.Data.Labajo_WebAppContext _context;

        public IndexModel(Labajo_WebApp.Data.Labajo_WebAppContext context)
        {
            _context = context;
        }

        public IList<CrudModels> CrudModels { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CrudModels != null)
            {
                CrudModels = await _context.CrudModels.ToListAsync();
            }
        }
    }
}
