using PersonasAPI.Entities;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Repositories;

namespace PersonasAPI.Services
{
	public class EmpresasService: IService<EmpresaDTO, int>
	{
		private readonly ICrudRepository<Empresa, int> empresasRepository;

        public EmpresasService(ICrudRepository<Empresa, int> empresasRepository)
        {
            this.empresasRepository = empresasRepository;
        }

		public EmpresaDTO? Add(EmpresaDTO empresaDTO)
		{
			Empresa savedEmpresa = new Empresa(empresaDTO.Nombre, empresaDTO.Dirección, empresaDTO.Telefono, empresaDTO.Empleados);
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
	}
}
