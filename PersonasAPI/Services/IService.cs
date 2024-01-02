namespace PersonasAPI.Services
{
	public interface IService<TDTO, Key>
	{
		IEnumerable<TDTO> GetAll();
		TDTO? GetById(Key key);
		TDTO? Add(TDTO entity);
		TDTO? Update(Key? key, TDTO entity);
		bool Delete(Key key);
	}
}
