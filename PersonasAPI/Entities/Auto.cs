using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonasAPI.Entities
{
	[Table("Autos")]
	public class Auto
	{
		[Key]
		public string Patente { get; set; }
		public string Marca { get; set; }
		public string Modelo { get; set; }
		public string Color { get; set; }


		public Auto()
		{

		}

        public Auto(string patente, string marca, string modelo, string color)
        {
			this.Patente = patente;
            this.Marca = marca;
			this.Modelo = modelo;
			this.Color = color;
        }
    }
}
