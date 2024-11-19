using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula_10.Models;

namespace Aula_10.Data
{
    public class Aula_10Context : DbContext
    {
        public Aula_10Context (DbContextOptions<Aula_10Context> options)
            : base(options)
        {
        }

        public DbSet<Aula_10.Models.Person> Person { get; set; } = default!;
    }
}
