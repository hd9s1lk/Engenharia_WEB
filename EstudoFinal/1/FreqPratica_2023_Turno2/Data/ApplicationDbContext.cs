using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FreqPratica_2023_Turno2.Models;

namespace FreqPratica_2023_Turno2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<FreqPratica_2023_Turno2.Models.Alugueres> Alugueres { get; set; } = default!;
}
