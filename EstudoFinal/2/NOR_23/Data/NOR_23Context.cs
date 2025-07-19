using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NOR_23.Models;

namespace NOR_23.Data
{
    public class NOR_23Context : DbContext
    {
        public NOR_23Context (DbContextOptions<NOR_23Context> options)
            : base(options)
        {
        }

        public DbSet<NOR_23.Models.Proprietario> Proprietario { get; set; } = default!;
        public DbSet<NOR_23.Models.VeiculoProprietarioViewModel> VeiculoProprietarioViewModel { get; set; } = default!;
        public DbSet<NOR_23.Models.Veiculo> Veiculo { get; set; } = default!;
    }
}
