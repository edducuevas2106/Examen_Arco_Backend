using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types.Entities;

namespace DataLayer.Communication
{
    public class EntitiesModel : DbContext
    {
        public readonly IConfiguration _configuration;

        public EntitiesModel(DbContextOptions<EntitiesModel> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;

        }

        public virtual DbSet<Marcas> Marca { get; set; }
        public virtual DbSet<SubMarca> Submarca { get; set; }
        public virtual DbSet<Modelos> Modelo { get; set; }
        public virtual DbSet<Descripcion> Descripcion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Descripcion>()
                .Property(d => d.DescripcionID)
                .HasDefaultValueSql("NEWID()");

            // Configuración de relaciones entre entidades
            modelBuilder.Entity<SubMarca>()
                .HasOne(s => s.Marca)
                .WithMany(m => m.Submarcas)
                .HasForeignKey(s => s.MarcaID);

            modelBuilder.Entity<Modelos>()
                .HasOne(m => m.Submarca)
                .WithMany(s => s.Modelos)
                .HasForeignKey(m => m.SubmarcaID);

            modelBuilder.Entity<Descripcion>()
                .HasOne(d => d.Modelo)
                .WithMany(m => m.Descripciones)
                .HasForeignKey(d => d.ModeloID);
        }
    }
}
