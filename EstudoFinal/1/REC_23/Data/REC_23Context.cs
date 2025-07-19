using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using REC_23.Models;

namespace REC_23.Data
{
    public class REC_23Context : DbContext
    {
        public REC_23Context (DbContextOptions<REC_23Context> options)
            : base(options)
        {
        }

        public DbSet<REC_23.Models.Aluno> Aluno { get; set; } = default!;
    }
}
