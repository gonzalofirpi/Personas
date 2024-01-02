namespace PersonasAPI.Entities.DTOs
{
	public class AutoDTO
	{
		public string Patente { get; set; }
		public string Marca { get; set; }
		public string Modelo { get; set; }
		public string Color { get; set; }

        public AutoDTO()
        {
            
        }

        public AutoDTO(Auto auto)
        {
            this.Patente = auto.Patente;
			this.Marca = auto.Marca;
			this.Modelo = auto.Modelo;
			this.Color = auto.Color;
        }
    }
}
