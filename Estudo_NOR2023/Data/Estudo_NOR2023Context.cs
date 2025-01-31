using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_NOR2023.Models;

namespace Estudo_NOR2023.Data
{
    public class Estudo_NOR2023Context : DbContext
    {
        public Estudo_NOR2023Context (DbContextOptions<Estudo_NOR2023Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_NOR2023.Models.Proprietario> Proprietario { get; set; } = default!;
        public DbSet<Estudo_NOR2023.Models.Veiculo> Veiculo { get; set; } = default!;
    }
}
