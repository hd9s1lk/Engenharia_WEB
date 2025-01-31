using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_Recurso23.Models;

namespace Final_Recurso23.Data
{
    public class Final_Recurso23Context : DbContext
    {
        public Final_Recurso23Context (DbContextOptions<Final_Recurso23Context> options)
            : base(options)
        {
        }

        public DbSet<Final_Recurso23.Models.Aluno> Aluno { get; set; } = default!;
    }
}
