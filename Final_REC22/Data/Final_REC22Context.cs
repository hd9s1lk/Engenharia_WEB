using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_REC22.Models;

namespace Final_REC22.Data
{
    public class Final_REC22Context : DbContext
    {
        public Final_REC22Context (DbContextOptions<Final_REC22Context> options)
            : base(options)
        {
        }

        public DbSet<Final_REC22.Models.Pais> Pais { get; set; } = default!;
    }
}
