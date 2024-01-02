using PersonasAPI.Entities;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Repositories;

namespace PersonasAPI.Services
{
	public class AutosService : IService<AutoDTO, string>
	{
		private readonly ICrudRepository<Auto, string> autosRepository;

		public AutosService(ICrudRepository<Auto, string> autosRepository)
		{
			this.autosRepository = autosRepository;
		}

		public AutoDTO? Add(AutoDTO auto)
		{
			Auto savedAuto = new Auto(auto.Patente, auto.Marca, auto.Modelo, auto.Color);
			this.autosRepository.Add(savedAuto);
			return new AutoDTO(savedAuto);
		}

		public bool Delete(string patente)
		{
			Auto optionalAuto = this.autosRepository.GetById(patente);

			if (optionalAuto == null)
			{
				return false;
			}

			this.autosRepository.Delete(optionalAuto);
			return true;
		}

		public IEnumerable<AutoDTO> GetAll()
		{
			return this.autosRepository.GetAll().Select(auto => new AutoDTO(auto));
		}

		public AutoDTO? GetById(string patente)
		{
			Auto optionalAuto = this.autosRepository.GetById(patente);
			return optionalAuto == null ? null : new AutoDTO(optionalAuto);
		}

		public AutoDTO? Update(string patente, AutoDTO autoDTO)
		{
			Auto optionalAuto = this.autosRepository.GetById(patente);

			if (optionalAuto == null) { return null; }

			optionalAuto.Marca = autoDTO.Marca;
			optionalAuto.Modelo = autoDTO.Modelo;
			optionalAuto.Color = autoDTO.Color;

			this.autosRepository.Update(optionalAuto);
			return new AutoDTO(optionalAuto);
		}
	}
}
