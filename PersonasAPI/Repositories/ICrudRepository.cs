namespace PersonasAPI.Repositories
{
	public interface ICrudRepository<T, Key>
	{
		IEnumerable<T> GetAll();
		T? GetById(Key id);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Save();
	}
}
