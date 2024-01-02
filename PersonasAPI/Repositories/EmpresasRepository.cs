using Microsoft.EntityFrameworkCore;
using PersonasAPI.Data;
using PersonasAPI.Entities;

namespace PersonasAPI.Repositories
{
	public class EmpresasRepository : ICrudRepository<Empresa, int>
	{
		private readonly ApplicationDbContext context;

        public EmpresasRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Empresa empresa)
		{
			this.context.Add(empresa);
			this.Save();
		}

		public void Delete(Empresa empresa)
		{
			this.context.Remove(empresa);
			this.Save();
		}

		public IEnumerable<Empresa> GetAll()
		{
			return this.context.Empresas
				.Include(empresa => empresa.Dirección)
				.Include(empresa => empresa.Empleados).ThenInclude(empleado => empleado.Autos)
				.Include(empresa => empresa.Empleados).ThenInclude(empleado => empleado.Titulos)
				.ToList();
		}

		public Empresa? GetById(int id)
		{
			return this.context.Empresas
				.Include(empresa => empresa.Dirección)
				.Include(empresa => empresa.Empleados).ThenInclude(empleado => empleado.Autos)
				.Include(empresa => empresa.Empleados).ThenInclude(empleado => empleado.Titulos)
				.FirstOrDefault(x => x.Id == id);
		}

		public void Save()
		{
			this.context.SaveChanges();
		}

		public void Update(Empresa empresa)
		{
			this.context.Update(empresa);
			this.Save();
		}
	}
}
