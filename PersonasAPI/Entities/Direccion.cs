using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PersonasAPI.Entities
{
	public class Direccion
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int Numero { get; set; }
		public string Calle {  get; set; }
		public int CodigoPostal { get; set;}

        public Direccion()
        {
            
        }

        public Direccion(int numero, string calle, int codigoPostal)
        {
            this.Numero = numero;
            this.Calle = calle;
            this.CodigoPostal = codigoPostal;
        }
    }
}
