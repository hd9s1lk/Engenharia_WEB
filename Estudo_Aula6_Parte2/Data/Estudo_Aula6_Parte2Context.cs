using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_Aula6_Parte2.Models;

namespace Estudo_Aula6_Parte2.Data
{
    public class Estudo_Aula6_Parte2Context : DbContext
    {
        public Estudo_Aula6_Parte2Context (DbContextOptions<Estudo_Aula6_Parte2Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_Aula6_Parte2.Models.Students> Students { get; set; } = default!;
    }
}
