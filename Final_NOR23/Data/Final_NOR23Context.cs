using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_NOR23.Models;

namespace Final_NOR23.Data
{
    public class Final_NOR23Context : DbContext
    {
        public Final_NOR23Context (DbContextOptions<Final_NOR23Context> options)
            : base(options)
        {
        }

        public DbSet<Final_NOR23.Models.Proprietario> Proprietario { get; set; } = default!;
        public DbSet<Final_NOR23.Models.Veiculo> Veiculo { get; set; } = default!;
    }
}
