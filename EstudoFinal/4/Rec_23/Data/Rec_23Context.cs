using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rec_23.Models;

namespace Rec_23.Data
{
    public class Rec_23Context : DbContext
    {
        public Rec_23Context (DbContextOptions<Rec_23Context> options)
            : base(options)
        {
        }

        public DbSet<Rec_23.Models.Aluno> Aluno { get; set; } = default!;
    }
}
