using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Areas.Models;

namespace Areas.Data
{
    public class AreasContext : DbContext
    {
        public AreasContext (DbContextOptions<AreasContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Cat> Cat { get; set; } = default!;
    }
}
