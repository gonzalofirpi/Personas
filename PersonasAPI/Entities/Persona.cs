using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonasAPI.Entities
{

	[Table("Personas")]
	public class Persona
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Documento { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public int Edad {  get; set; }
		public ICollection<Auto> Autos { get; set; }
		public ICollection<Titulo> Titulos { get; set; }



        public Persona()
        {
        }

        public Persona(string nombre, string apellido, int edad, ICollection<Auto> autos, ICollection<Titulo> titulos)
        {
            this.Nombre = nombre;
			this.Apellido = apellido;
			this.Edad = edad;
			this.Autos = autos;
			this.Titulos = titulos;
        }
    }
}
