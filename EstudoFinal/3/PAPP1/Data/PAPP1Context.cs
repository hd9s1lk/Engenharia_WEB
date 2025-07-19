using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PAPP1.Models;

namespace PAPP1.Data
{
    public class PAPP1Context : DbContext
    {
        public PAPP1Context (DbContextOptions<PAPP1Context> options)
            : base(options)
        {
        }

        public DbSet<PAPP1.Models.Carro> Carro { get; set; } = default!;
    }
}
