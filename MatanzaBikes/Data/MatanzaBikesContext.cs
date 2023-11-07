using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MatanzaBikes.Model;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Drawing;
using Faker;

namespace MatanzaBikes.Data
{
    public partial class MatanzaBikesContext : DbContext
    {
        public MatanzaBikesContext()
        {
        }

        public MatanzaBikesContext(DbContextOptions<MatanzaBikesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Moto> Motos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=MatanzaBikes:ConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Marca>()
                .HasMany<Moto>()
                .WithOne()
                .HasForeignKey(e => e.MarcaId)
                .IsRequired();

            List<string> marcas = new List<string> { "Ducati", "Harley Davidson", "Honda", "Yamaha" };
            foreach (var marca in marcas)
            {
                modelBuilder.Entity<Marca>().HasData(
                 new Marca() { Id = marcas.IndexOf(marca) + 1, Nombre = marca }
                 );
            }

            List<Moto> motos = new List<Moto> { };

            for (int i = 0; i < 10; i++)
            {
                Moto moto = new Moto()
                {
                    Id = i + 3,
                    MarcaId = Faker.NumberFaker.Number(1, 4),
                    Modelo = Faker.LocationFaker.Country(),
                    Cilindrada = "650",
                    Color = "Verde",
                    Año = 2023,
                    Motor = "4 tiempos",
                    Bateria = "12",
                    Peso = Faker.NumberFaker.Number(100, 400),
                    Rodado = Faker.NumberFaker.Number(0, 400),
                    Suspension = "Hidraulica",
                    Frenos = "Disco",
                    Stock = Faker.NumberFaker.Number(0, 1001),
                    Precio = Faker.NumberFaker.Number(0, 400)
                };
                motos.Add(moto);
            }
            modelBuilder.Entity<Moto>().HasData(motos);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}