using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_NOR24.Models;

    public class DB_al78804 : DbContext
    {
        public DB_al78804 (DbContextOptions<DB_al78804> options)
            : base(options)
        {
        }

        public DbSet<Final_NOR24.Models.RegistoUtilizador> RegistoUtilizador { get; set; } = default!;
    }
