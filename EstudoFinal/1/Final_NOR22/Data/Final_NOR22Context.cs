using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_NOR22.Models;

namespace Final_NOR22.Data
{
    public class Final_NOR22Context : DbContext
    {
        public Final_NOR22Context (DbContextOptions<Final_NOR22Context> options)
            : base(options)
        {
        }

        public DbSet<Final_NOR22.Models.Empresa> Empresa { get; set; } = default!;
    }
}
