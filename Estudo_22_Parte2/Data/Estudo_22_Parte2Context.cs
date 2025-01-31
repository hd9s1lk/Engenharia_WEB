using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_22_Parte2.Models;

namespace Estudo_22_Parte2.Data
{
    public class Estudo_22_Parte2Context : DbContext
    {
        public Estudo_22_Parte2Context (DbContextOptions<Estudo_22_Parte2Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_22_Parte2.Models.Pais> Pais { get; set; } = default!;
    }
}
