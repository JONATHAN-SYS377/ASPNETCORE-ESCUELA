using Escuela_Sor_Maria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Escuela_Sor_Maria.Models.tbProvicia;

namespace Escuela_Sor_Maria.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        public DbSet<tbProfesores> tbPersona { get; set; }
        public DbSet<tbProvincia> tbProvincia { get; set; }
        public DbSet<tbCanton> tbCanton { get; set; }
        public DbSet<tbDistrito> tbDistrito { get; set; }
        public DbSet<tbBarrios> tbBarrios { get; set; }

        public DbSet<tbAlumnos> tbAlumnos {get; set;} 
        public DbSet<tbCursos> tbCursos {get; set;} 
        public DbSet<tbMaterias> tbMaterias {get; set;} 
        public DbSet<tbCalificaciones> tbCalificaciones
        {get; set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<tbProvincia>()
                .HasKey(p => p.Cod);

            modelBuilder.Entity<tbCanton>()
                .HasKey(c => new { c.ProvinciaID, c.Canton });

            modelBuilder.Entity<tbDistrito>()
                .HasKey(d => new { d.ProvinciaID, d.CantonID, d.Distrito });

            modelBuilder.Entity<tbBarrios>()
                .HasKey(b => new { b.ProvinciaID, b.CantonID, b.DistritoID, b.Barrio });

            modelBuilder.Entity<tbDistrito>()
                .HasOne(d => d.Canton)
                .WithMany(c => c.Distritos)
                .HasForeignKey(d => new { d.ProvinciaID, d.CantonID });

            modelBuilder.Entity<tbBarrios>()
                .HasOne(b => b.Distrito)
                .WithMany(d => d.Barrios)
                .HasForeignKey(b => new { b.ProvinciaID, b.CantonID, b.DistritoID });
        }

        public DbSet<Escuela_Sor_Maria.Models.Alumno_Ubicacion> Alumno_Ubicacion { get; set; } = default!;
    }
}