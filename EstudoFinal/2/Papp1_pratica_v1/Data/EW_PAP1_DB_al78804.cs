using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Papp1_pratica_v1.Models;

    public class EW_PAP1_DB_al78804 : DbContext
    {
        public EW_PAP1_DB_al78804 (DbContextOptions<EW_PAP1_DB_al78804> options)
            : base(options)
        {
        }

        public DbSet<Papp1_pratica_v1.Models.Carro> Carro { get; set; } = default!;
    }
