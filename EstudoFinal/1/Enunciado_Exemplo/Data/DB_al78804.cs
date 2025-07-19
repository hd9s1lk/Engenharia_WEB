using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Enunciado_Exemplo.Models;

public class DB_al78804 : DbContext
{
    public DB_al78804(DbContextOptions<DB_al78804> options)
        : base(options)
    {
    }

    public DbSet<Enunciado_Exemplo.Models.Aluno> Aluno { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Aluno>()
            .HasIndex(p => p.Numero)
            .IsUnique();

        modelBuilder.Entity<Aluno>()
            .HasIndex(p => p.Email)
            .IsUnique();


    }
}
