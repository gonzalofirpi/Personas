using PersonasAPI.Entities;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Repositories;

namespace PersonasAPI.Services
{
    public class PersonasService: IService<PersonaDTO, long>
	{
		private readonly ICrudRepository<Persona, long> personasRepository;

		public PersonasService(ICrudRepository<Persona, long> personasRepository)
		{
			this.personasRepository = personasRepository;
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
			Persona savedPersonda = new Persona(personaDTO.Nombre, personaDTO.Apellido, personaDTO.Edad, personaDTO.Autos, personaDTO.Titulos);
			this.personasRepository.Add(savedPersonda);
			return new PersonaDTO(savedPersonda);
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
