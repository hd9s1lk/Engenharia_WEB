using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_Exemplo1.Models;

namespace Estudo_Exemplo1.Data
{
    public class Estudo_Exemplo1Context : DbContext
    {
        public Estudo_Exemplo1Context (DbContextOptions<Estudo_Exemplo1Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_Exemplo1.Models.Carro> Carro { get; set; } = default!;

        public DbSet<Estudo_Exemplo1.Models.Pessoa> Pessoa { get; set; } = default!;
    }
}
