using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NOR_24.Models;

public class DB_al78804 : DbContext
{
    public DB_al78804(DbContextOptions<DB_al78804> options)
        : base(options)
    {
    }

    public DbSet<NOR_24.Models.RegistoUtilizador> RegistoUtilizador { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RegistoUtilizador>()
            .HasIndex(p => p.RegistoId)
            .IsUnique();
    }
}
