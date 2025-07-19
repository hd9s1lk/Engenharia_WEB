using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using papp1.Models;

namespace papp1.Data
{
    public class papp1Context : DbContext
    {
        public papp1Context (DbContextOptions<papp1Context> options)
            : base(options)
        {
        }

        public DbSet<papp1.Models.Carro> Carro { get; set; } = default!;
    }
}
