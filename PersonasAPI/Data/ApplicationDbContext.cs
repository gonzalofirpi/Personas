using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using PersonasAPI.Entities;

namespace PersonasAPI.Data
{
	public class ApplicationDbContext: DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Auto>()
				.HasOne<Persona>()
				.WithMany(p => p.Autos)
				.HasForeignKey("dueño");

			modelBuilder.Entity<Titulo>()
				.HasOne<Persona>()
				.WithMany(p => p.Titulos)
				.HasForeignKey("persona");

			modelBuilder.Entity<Empresa>()
				.HasOne(empresa => empresa.Dirección)
				.WithOne()
				.HasForeignKey<Empresa>("direccion");

			modelBuilder.Entity<Persona>()
				.HasOne<Empresa>()
				.WithMany(empresa => empresa.Empleados)
				.HasForeignKey("empresa");
		}

		public DbSet<Persona> Personas { get; set; }
        public DbSet<Auto> Autos {  get; set; }
		public DbSet<Direccion> Direcciones { get; set; }
		public DbSet<Empresa> Empresas { get; set; }


    }
}
