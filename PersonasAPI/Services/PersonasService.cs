using PersonasAPI.Entities;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Repositories;

namespace PersonasAPI.Services
{
	public class PersonasService : IService<PersonaDTO, long>
	{
		private readonly ICrudRepository<Persona, long> personasRepository;
		private readonly ICrudRepository<Auto, string> autosRepository;

		public PersonasService(ICrudRepository<Persona, long> personasRepository, ICrudRepository<Auto, string> autosRepository)
		{
			this.personasRepository = personasRepository;
			this.autosRepository = autosRepository;
		}

		public IEnumerable<PersonaDTO> GetAll()
		{
			return this.personasRepository.GetAll().Select(persona => new PersonaDTO(persona));
		}

		public PersonaDTO? GetById(long document)
		{
			Persona optionalPersona = this.personasRepository.GetById(document);

			return optionalPersona == null ? null : new PersonaDTO(optionalPersona);
		}

		public PersonaDTO? Add(PersonaDTO personaDTO)
		{
			Persona savedPersona = new Persona();

			if (personaDTO.Autos != null)
			{

				List<AutoDTO> autosDTO = personaDTO.Autos.Select(auto => new AutoDTO(auto)).ToList();
				List<Auto> autos = new List<Auto>();

				foreach (AutoDTO autoDTO in autosDTO)
				{
					Auto auto = this.autosRepository.GetById(autoDTO.Patente);

					if (auto != null)
					{
						autos.Add(auto);
					}
					else
					{
						autos.Add(new Auto(autoDTO.Patente, autoDTO.Marca, autoDTO.Modelo, autoDTO.Color));
					}
				}

				savedPersona.Autos = autos;
			}

			savedPersona.Nombre = personaDTO.Nombre;
			savedPersona.Apellido = personaDTO.Apellido;
			savedPersona.Edad = personaDTO.Edad;

			if (personaDTO.Titulos != null)
			{
				savedPersona.Titulos = personaDTO.Titulos;
			}
			else savedPersona.Titulos = null;

			this.personasRepository.Add(savedPersona);
			return new PersonaDTO(savedPersona);
		}

		public PersonaDTO? Update(long document, PersonaDTO personaDTO)
		{
			Persona optionalPersona = personasRepository.GetById(document);

			if (optionalPersona == null)
			{
				return null;
			}

			optionalPersona.Nombre = personaDTO.Nombre;
			optionalPersona.Apellido = personaDTO.Apellido;
			optionalPersona.Edad = personaDTO.Edad;
			optionalPersona.Autos = personaDTO.Autos;
			optionalPersona.Titulos = personaDTO.Titulos;

			this.personasRepository.Update(optionalPersona);
			return new PersonaDTO(optionalPersona);
		}

		public bool Delete(long document)
		{
			Persona optionalPersona = personasRepository.GetById(document);

			if (optionalPersona == null)
			{
				return false;
			}

			this.personasRepository.Delete(optionalPersona);
			return true;
		}
	}
}
