﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Papp1_pratica_v1.Migrations
{
    [DbContext(typeof(EW_PAP1_DB_al78804))]
    partial class EW_PAP1_DB_al78804ModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Papp1_pratica_v1.Models.Carro", b =>
                {
                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vendido")
                        .HasColumnType("bit");

                    b.HasKey("Marca");

                    b.ToTable("Carro");
                });
#pragma warning restore 612, 618
        }
    }
}
