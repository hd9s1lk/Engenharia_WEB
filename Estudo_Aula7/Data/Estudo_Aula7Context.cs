using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_Aula7.Models;

namespace Estudo_Aula7.Data
{
    public class Estudo_Aula7Context : DbContext
    {
        public Estudo_Aula7Context (DbContextOptions<Estudo_Aula7Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_Aula7.Models.User> User { get; set; } = default!;
    }
}
