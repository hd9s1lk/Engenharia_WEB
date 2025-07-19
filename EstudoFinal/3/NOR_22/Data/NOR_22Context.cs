using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NOR_22.Models;

namespace NOR_22.Data
{
    public class NOR_22Context : DbContext
    {
        public NOR_22Context (DbContextOptions<NOR_22Context> options)
            : base(options)
        {
        }

        public DbSet<NOR_22.Models.Empresa> Empresa { get; set; } = default!;
    }
}
