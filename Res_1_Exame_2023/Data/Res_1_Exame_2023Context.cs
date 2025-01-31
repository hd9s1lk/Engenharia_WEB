using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Res_1_Exame_2023.Models;

namespace Res_1_Exame_2023.Data
{
    public class Res_1_Exame_2023Context : DbContext
    {
        public Res_1_Exame_2023Context (DbContextOptions<Res_1_Exame_2023Context> options)
            : base(options)
        {
        }

        public DbSet<Res_1_Exame_2023.Models.Proprietario> Proprietario { get; set; } = default!;
        public DbSet<Res_1_Exame_2023.Models.Veiculo> Veiculo { get; set; } = default!;
    }
}
