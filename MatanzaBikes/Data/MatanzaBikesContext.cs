using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MatanzaBikes.Model;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Drawing;

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
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-QA3T2VH6\\SQLEXPRESS;Initial Catalog=MatanzaBikes;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
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

            modelBuilder.Entity<Moto>().HasData(new Moto() {
                Id = 1,
                MarcaId = 1,
                Modelo = "KLT 650",
                Cilindrada = "650",
                Color = "Verde",
                Año = 2023,
                Motor = "4 tiempos",
                Bateria = "12",
                Peso = 160,
                Rodado = 118,
                Suspension = "Hidraulica",
                Frenos = "Disco",
                Stock = 5,
                Precio = 11067000M
            });

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
