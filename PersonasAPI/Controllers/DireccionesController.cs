using Microsoft.AspNetCore.Mvc;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Services;

namespace PersonasAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DireccionesController : ControllerBase
	{
		private readonly IService<DireccionDTO, int> direccionesService;

		public DireccionesController(IService<DireccionDTO, int> direccionesService)
		{
			this.direccionesService = direccionesService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult GetAll()
		{
			IEnumerable<DireccionDTO> direcciones = this.direccionesService.GetAll();

			if (direcciones.Count() == 0) { return NoContent(); }

			return Ok(direcciones);
		}

		[HttpGet]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<DireccionDTO> GetById([FromRoute] int id)
		{
			DireccionDTO direccion = this.direccionesService.GetById(id);

			if (direccion == null) { return NotFound(); }

			return Ok(direccion);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<DireccionDTO> Add([FromBody] DireccionDTO direccionDTO)
		{
			if (direccionDTO == null) { return BadRequest(); }

			DireccionDTO savedDireccion = this.direccionesService.Add(direccionDTO);
			return Ok(savedDireccion);
		}

		[HttpPut]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<DireccionDTO> Update([FromRoute] int id, [FromBody] DireccionDTO direccionDTO)
		{
			if (direccionDTO == null) { return BadRequest(); }

			DireccionDTO optionalDireccion = this.direccionesService.Update(id, direccionDTO);

			if (optionalDireccion == null) { return NotFound(); }

			return Ok(optionalDireccion);
		}

		[HttpDelete]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult Delete([FromRoute] int id)
		{
			bool result = this.direccionesService.Delete(id);

			if (!result) { return NotFound(); }

			return Ok();
		}
	}
}
