using System;
using System.Collections.Generic;
using Estudo_Aula6.Models;
using Microsoft.EntityFrameworkCore;

namespace Estudo_Aula6.Data;

public partial class Estudo_Aula6 : DbContext
{
    public Estudo_Aula6()
    {
    }

    public Estudo_Aula6(DbContextOptions<Estudo_Aula6> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("name=Estudo_Aula6");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Class>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__Class__3214EC27EAF48B30");
    //    });

    //    modelBuilder.Entity<Student>(entity =>
    //    {
    //        entity.HasKey(e => e.Number).HasName("PK__Student__78A1A19CB71FB7CB");

    //        entity.Property(e => e.Number).ValueGeneratedNever();

    //        entity.HasOne(d => d.Class).WithMany(p => p.Students).HasConstraintName("FK__Student__ClassID__267ABA7A");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
