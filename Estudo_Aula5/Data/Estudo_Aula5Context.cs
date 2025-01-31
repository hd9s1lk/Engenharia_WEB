using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudo_Aula5.Models;

namespace Estudo_Aula5.Data
{
    public class Estudo_Aula5Context : DbContext
    {
        public Estudo_Aula5Context (DbContextOptions<Estudo_Aula5Context> options)
            : base(options)
        {
        }

        public DbSet<Estudo_Aula5.Models.Book> Book { get; set; } = default!;
    }
}
