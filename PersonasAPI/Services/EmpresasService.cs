using PersonasAPI.Entities;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Repositories;

namespace PersonasAPI.Services
{
	public class EmpresasService : IService<EmpresaDTO, int>
	{
		private readonly ICrudRepository<Empresa, int> empresasRepository;
		private readonly ICrudRepository<Persona, long> personasRepository;
		private readonly ICrudRepository<Direccion, int> direccionesRepository;

		public EmpresasService(ICrudRepository<Empresa, int> empresasRepository, ICrudRepository<Persona, long> personasRepository, ICrudRepository<Direccion, int> direccionesRepository)
		{
			this.empresasRepository = empresasRepository;
			this.personasRepository = personasRepository;
			this.direccionesRepository = direccionesRepository;
		}

		public EmpresaDTO? Add(EmpresaDTO empresaDTO)
		{
			Empresa savedEmpresa = new Empresa();

			// Agregar empleados
			savedEmpresa.Empleados = CargarEmpleados(empresaDTO.Empleados == null? null : empresaDTO.Empleados.ToList());

			// Agregar dirección
			savedEmpresa.Dirección = CargarDireccion(empresaDTO.Dirección);

			// Agregar resto de atriburos
			savedEmpresa.Nombre = empresaDTO.Nombre;
			savedEmpresa.Telefono = empresaDTO.Telefono;

			this.empresasRepository.Add(savedEmpresa);
			return new EmpresaDTO(savedEmpresa);
		}

		public bool Delete(int id)
		{
			Empresa optionalEmpresa = this.empresasRepository.GetById(id);
			if (optionalEmpresa == null) { return false; }

			this.empresasRepository.Delete(optionalEmpresa);
			return true;
		}

		public IEnumerable<EmpresaDTO> GetAll()
		{
			return this.empresasRepository.GetAll().Select(empresa => new EmpresaDTO(empresa));
		}

		public EmpresaDTO? GetById(int id)
		{
			Empresa optionalEmpresa = this.empresasRepository.GetById(id);
			return optionalEmpresa == null ? null : new EmpresaDTO(optionalEmpresa);
		}

		public EmpresaDTO? Update(int id, EmpresaDTO empresaDTO)
		{
			Empresa optionalEmpresa = this.empresasRepository.GetById(id);

			if (optionalEmpresa == null) { return null; }

			optionalEmpresa.Nombre = empresaDTO.Nombre;
			optionalEmpresa.Dirección = empresaDTO.Dirección;
			optionalEmpresa.Telefono = empresaDTO.Telefono;
			optionalEmpresa.Empleados = empresaDTO.Empleados;

			this.empresasRepository.Update(optionalEmpresa);
			return new EmpresaDTO(optionalEmpresa);
		}

		public List<Persona>? CargarEmpleados(List<Persona>? personas)
		{

			if (personas == null) { return null; }

			List<PersonaDTO> personasDTO  = personas.Select(persona => new PersonaDTO(persona)).ToList();
			List<Persona> empleados = new List<Persona>();

			foreach (PersonaDTO personaDTO in personasDTO)
			{
				if (personaDTO.Documento != null)
				{
					Persona persona = this.personasRepository.GetById(personaDTO.Documento);

					if (persona != null)
					{
						empleados.Add(persona);
					}
					else
					{
						empleados.Add(new Persona(personaDTO.Nombre, personaDTO.Apellido, personaDTO.Edad, personaDTO.Autos == null ? null : personaDTO.Autos));
					}

				}
				else
				{
					empleados.Add(new Persona(personaDTO.Nombre, personaDTO.Apellido, personaDTO.Edad, personaDTO.Autos == null ? null : personaDTO.Autos));
				}
			}

			return empleados;
		}

		public Direccion CargarDireccion(Direccion direccion)
		{
			if (direccion.Id != null)
			{
				Direccion savedDireccion = this.direccionesRepository.GetById(direccion.Id);

				if (savedDireccion != null) { return savedDireccion; }
				else { return new Direccion(direccion.Numero, direccion.Calle, direccion.CodigoPostal); }
			}
			else
			{
				return new Direccion(direccion.Numero, direccion.Calle, direccion.CodigoPostal);
			}
		}
	}
}
