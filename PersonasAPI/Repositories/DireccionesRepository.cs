using PersonasAPI.Data;
using PersonasAPI.Entities;

namespace PersonasAPI.Repositories
{
	public class DireccionesRepository : ICrudRepository<Direccion, int>
	{
		private readonly ApplicationDbContext context;

        public DireccionesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Direccion direccion)
		{
			this.context.Add(direccion);
			this.Save();
		}

		public void Delete(Direccion direccion)
		{
			this.context.Remove(direccion);
			this.Save();
		}

		public IEnumerable<Direccion> GetAll()
		{
			return this.context.Direcciones.ToList();
		}

		public Direccion? GetById(int id)
		{
			return this.context.Direcciones.FirstOrDefault(d => d.Id == id);
		}

		public Direccion? FindById(int id)
		{
			return this.context.Direcciones.Find(id);
		}

		public void Save()
		{
			this.context.SaveChanges();
		}

		public void Update(Direccion entity)
		{
			this.context.Update(entity);
			this.Save();
		}
	}
}
