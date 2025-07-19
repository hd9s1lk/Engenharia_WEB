using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pratica_2020_Turno2.Models;

    public class EW_PAP1_DB_al78804 : DbContext
    {
        public EW_PAP1_DB_al78804 (DbContextOptions<EW_PAP1_DB_al78804> options)
            : base(options)
        {
        }

        public DbSet<Pratica_2020_Turno2.Models.Carro> Carro { get; set; } = default!;
    }
