namespace PersonasAPI.Entities.DTOs
{
	public class EmpresaDTO
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public Direccion Dirección { get; set; }
		public string Telefono { get; set; }
		public ICollection<Persona>? Empleados { get; set; }

		public EmpresaDTO()
		{

		}

		public EmpresaDTO(Empresa empresa)
		{
			this.Id = empresa.Id;
			this.Nombre = empresa.Nombre;
			this.Dirección = empresa.Dirección;
			this.Telefono = empresa.Telefono;

			if (empresa.Empleados != null)
			{
				this.Empleados = empresa.Empleados;
			}
		}
	}
}
