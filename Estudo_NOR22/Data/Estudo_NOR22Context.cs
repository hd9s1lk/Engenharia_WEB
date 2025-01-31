using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_NOR22.Models;

namespace Estudo_NOR22.Data
{
    public class Estudo_NOR22Context : DbContext
    {
        public Estudo_NOR22Context (DbContextOptions<Estudo_NOR22Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_NOR22.Models.Empresa> Empresa { get; set; } = default!;
    }
}
