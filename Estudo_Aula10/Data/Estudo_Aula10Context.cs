using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_Aula10.Models;

namespace Estudo_Aula10.Data
{
    public class Estudo_Aula10Context : DbContext
    {
        public Estudo_Aula10Context (DbContextOptions<Estudo_Aula10Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_Aula10.Models.Person> Person { get; set; } = default!;
    }
}
