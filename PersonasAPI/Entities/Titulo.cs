using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonasAPI.Entities
{
	[Table("Titulos")]
	public class Titulo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Matricula { get; set; }
		public string Descripcion { get; set; }
	}
}
