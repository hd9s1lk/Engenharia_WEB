﻿// <auto-generated />
using System;
using Estudo_Exemplo1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Estudo_Exemplo1.Migrations
{
    [DbContext(typeof(Estudo_Exemplo1Context))]
    [Migration("20250116153056_Foto")]
    partial class Foto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarroPessoa", b =>
                {
                    b.Property<int>("CarrosId")
                        .HasColumnType("int");

                    b.Property<int>("PessoasId")
                        .HasColumnType("int");

                    b.HasKey("CarrosId", "PessoasId");

                    b.HasIndex("PessoasId");

                    b.ToTable("CarroPessoa");
                });

            modelBuilder.Entity("Estudo_Exemplo1.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Fotografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Marca")
                        .IsUnique();

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("Estudo_Exemplo1.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Vendas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("CarroPessoa", b =>
                {
                    b.HasOne("Estudo_Exemplo1.Models.Carro", null)
                        .WithMany()
                        .HasForeignKey("CarrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Estudo_Exemplo1.Models.Pessoa", null)
                        .WithMany()
                        .HasForeignKey("PessoasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
