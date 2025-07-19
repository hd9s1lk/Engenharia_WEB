using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FreqPratica2_23.Models;

namespace FreqPratica2_23.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<FreqPratica2_23.Models.BolsaInvestigacao> BolsaInvestigacao { get; set; } = default!;
}
