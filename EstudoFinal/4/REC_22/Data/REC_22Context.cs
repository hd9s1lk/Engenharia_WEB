using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using REC_22.Models;

namespace REC_22.Data
{
    public class REC_22Context : DbContext
    {
        public REC_22Context (DbContextOptions<REC_22Context> options)
            : base(options)
        {
        }

        public DbSet<REC_22.Models.Pais> Pais { get; set; } = default!;
        public DbSet<REC_22.Models.Empresa> Empresa { get; set; } = default!;
    }
}
