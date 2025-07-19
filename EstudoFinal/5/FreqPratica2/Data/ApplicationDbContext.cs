using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FreqPratica2.Models;

namespace FreqPratica2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<FreqPratica2.Models.BolsaInvestigacao> BolsaInvestigacao { get; set; } = default!;
}
