using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_Pratica2023.Models;

namespace Estudo_Pratica2023.Data
{
    public class Estudo_Pratica2023Context : DbContext
    {
        public Estudo_Pratica2023Context (DbContextOptions<Estudo_Pratica2023Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_Pratica2023.Models.Aluno> Aluno { get; set; } = default!;
    }
}
