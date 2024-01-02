namespace PersonasAPI.Entities.DTOs
{
	public class PersonaDTO
	{
		public long Documento { get; set; }

		public string Nombre { get; set; }

		public string Apellido { get; set; }

		public int Edad { get; set; }

		public ICollection<Auto> Autos { get; set; }

		public ICollection<Titulo> Titulos { get; set; }

		public PersonaDTO() { }

		public PersonaDTO(Persona persona)
		{
			this.Documento = persona.Documento;
			this.Nombre = persona.Nombre;
			this.Apellido = persona.Apellido;
			this.Edad = persona.Edad;
			this.Autos = persona.Autos;
			this.Titulos = persona.Titulos;
		}
	}
}
