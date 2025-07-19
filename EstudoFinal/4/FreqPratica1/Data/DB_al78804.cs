using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FreqPratica1.Models;

public class DB_al78804 : DbContext
{
    public DB_al78804(DbContextOptions<DB_al78804> options)
        : base(options)
    {
    }

    public DbSet<FreqPratica1.Models.Contacto> Contacto { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contacto>()
            .HasIndex(p => p.Email)
            .IsUnique();


    }
}
