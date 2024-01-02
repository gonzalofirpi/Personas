using PersonasAPI.Entities;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Repositories;

namespace PersonasAPI.Services
{
	public class DireccionesService : IService<DireccionDTO, int>
	{
		private readonly ICrudRepository<Direccion, int> direccionesRepository;

        public DireccionesService(ICrudRepository<Direccion, int> direccionesRepository)
        {
            this.direccionesRepository = direccionesRepository;
        }

        public DireccionDTO? Add(DireccionDTO direccion)
		{
			Direccion savedDireccion = new Direccion(direccion.Numero, direccion.Calle, direccion.CodigoPostal);
			this.direccionesRepository.Add(savedDireccion);
			return new DireccionDTO(savedDireccion);
		}

		public bool Delete(int id)
		{
			Direccion optionalDireccion = this.direccionesRepository.GetById(id);

			if (optionalDireccion == null) { return false; }

			this.direccionesRepository.Delete(optionalDireccion);
			return true;
		}

		public IEnumerable<DireccionDTO> GetAll()
		{
			return this.direccionesRepository.GetAll().Select(direccion => new DireccionDTO(direccion));
		}

		public DireccionDTO? GetById(int id)
		{
			Direccion optionalDireccion = this.direccionesRepository.GetById(id);

			return optionalDireccion == null ? null : new DireccionDTO(optionalDireccion);
		}

		public DireccionDTO? Update(int id, DireccionDTO direccion)
		{
			Direccion optionalDireccion = this.direccionesRepository.GetById(id);

			if (optionalDireccion == null) { return null; }

			optionalDireccion.Numero = direccion.Numero;
			optionalDireccion.Calle = direccion.Calle;
			optionalDireccion.CodigoPostal = direccion.CodigoPostal;

			this.direccionesRepository.Update(optionalDireccion);
			return new DireccionDTO(optionalDireccion);
		}
	}
}
