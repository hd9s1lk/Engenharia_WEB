using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_Aula3.Models;

namespace Estudo_Aula3.Data
{
    public class Estudo_Aula3Context : DbContext
    {
        public Estudo_Aula3Context (DbContextOptions<Estudo_Aula3Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_Aula3.Models.Category> Category { get; set; } = default!;

        public DbSet<Estudo_Aula3.Models.Course> Course { get; set; } = default!;
    }
}
