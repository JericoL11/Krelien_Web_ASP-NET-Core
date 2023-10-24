using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Labajo_WebApp.Models;

namespace Labajo_WebApp.Data
{
    public class Labajo_WebAppContext : DbContext
    {
        public Labajo_WebAppContext (DbContextOptions<Labajo_WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Labajo_WebApp.Models.CrudModels> CrudModels { get; set; } = default!;
    }
}
