using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using RecursosHumanos.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RecursosHumanos.DAL
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }
        public DbSet<RecursosHumanos.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<RecursosHumanos.Models.Departamento> Departamento { get; set; } = default!;
        public DbSet<RecursosHumanos.Models.Roles> Roles { get; set; } = default!;
        public DbSet<RecursosHumanos.Models.Empleado> Empleado { get; set; } = default!;
        public DbSet<RecursosHumanos.Models.Asistencia> Asistencia { get; set; } = default!;
        public DbSet<RecursosHumanos.Models.Excusas> Excusas { get; set; } = default!;
        public DbSet<RecursosHumanos.Models.Documentos> Documentos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .Property(m => m.Cedula)
                .ValueGeneratedNever(); // Desactiva la generación automática

            modelBuilder.Entity<Empleado>()
                .HasKey(m => m.Cedula); // Define la clave primaria

            base.OnModelCreating(modelBuilder);
        }
    }
}
