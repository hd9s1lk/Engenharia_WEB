﻿// <auto-generated />
using Final_Recurso23.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Final_Recurso23.Migrations
{
    [DbContext(typeof(Final_Recurso23Context))]
    partial class Final_Recurso23ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Final_Recurso23.Models.Aluno", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"));

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<float>("Pratica")
                        .HasColumnType("real");

                    b.Property<float>("Teorica")
                        .HasColumnType("real");

                    b.HasKey("Numero");

                    b.ToTable("Aluno");
                });
#pragma warning restore 612, 618
        }
    }
}
