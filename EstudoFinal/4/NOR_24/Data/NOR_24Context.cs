using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NOR_24.Models;

namespace NOR_24.Data
{
    public class NOR_24Context : DbContext
    {
        public NOR_24Context (DbContextOptions<NOR_24Context> options)
            : base(options)
        {
        }

        public DbSet<NOR_24.Models.RegistoUtilizador> RegistoUtilizador { get; set; } = default!;
    }
}
