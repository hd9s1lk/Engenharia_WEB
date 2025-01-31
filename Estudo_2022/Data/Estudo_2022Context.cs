using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_2022.Models;

namespace Estudo_2022.Data
{
    public class Estudo_2022Context : DbContext
    {
        public Estudo_2022Context (DbContextOptions<Estudo_2022Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_2022.Models.Pais> Pais { get; set; } = default!;
    }
}
