namespace PersonasAPI.Entities.DTOs
{
	public class DireccionDTO
	{
		public int Id { get; set; }
		public int Numero { get; set; }
		public string Calle { get; set; }
		public int CodigoPostal { get; set; }

        public DireccionDTO()
        {
            
        }

        public DireccionDTO(Direccion direccion)
        {
            this.Id = direccion.Id;
            this.Numero = direccion.Numero;
            this.Calle = direccion.Calle;
            this.CodigoPostal = direccion.CodigoPostal;
        }
    }
}
