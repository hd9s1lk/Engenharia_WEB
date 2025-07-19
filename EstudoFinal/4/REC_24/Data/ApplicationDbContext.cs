using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using REC_24.Models;

namespace REC_24.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<REC_24.Models.RegistoNota> RegistoNota { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RegistoNota>()
            .HasIndex(p => p.NumAluno)
            .IsUnique();

        modelBuilder.Entity<RegistoNota>()
            .HasIndex(p => p.Id)
            .IsUnique();

    }
}
