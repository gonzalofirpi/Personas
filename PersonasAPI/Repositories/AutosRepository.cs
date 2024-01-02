using PersonasAPI.Data;
using PersonasAPI.Entities;

namespace PersonasAPI.Repositories
{
	public class AutosRepository : ICrudRepository<Auto, string>
	{
		private readonly ApplicationDbContext context;

        public AutosRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Auto entity)
		{
			this.context.Add(entity);
			this.Save();
		}

		public void Delete(Auto entity)
		{
			this.context.Remove(entity);
			this.Save();
		}

		public IEnumerable<Auto> GetAll()
		{
			return this.context.Autos.ToList();
		}

		public Auto? GetById(string id)
		{
			return this.context.Autos.FirstOrDefault(x => x.Patente == id);
		}

		public void Save()
		{
			this.context.SaveChanges();
		}

		public void Update(Auto entity)
		{
			this.context.Update(entity);
			this.Save();	
		}
	}
}
