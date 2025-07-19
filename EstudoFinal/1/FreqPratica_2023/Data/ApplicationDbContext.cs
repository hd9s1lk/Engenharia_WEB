using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FreqPratica_2023.Models;

namespace FreqPratica_2023.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<FreqPratica_2023.Models.BolsaInvestigacao> BolsaInvestigacao { get; set; } = default!;
}
