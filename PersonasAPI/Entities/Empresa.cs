using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonasAPI.Entities
{
	public class Empresa
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Nombre { get; set; }
		public Direccion Dirección { get; set; }
		public string Telefono { get; set; }
		public ICollection<Persona> Empleados { get; set; }

        public Empresa()
        {
            
        }

        public Empresa(string nombre, Direccion direccion, string telefono, ICollection<Persona> empleados)
        {
            this.Nombre = nombre;
			this.Dirección = direccion;
			this.Telefono = telefono;
			this.Empleados = empleados;
        }
    }
}
