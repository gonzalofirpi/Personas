using Microsoft.AspNetCore.Mvc;
using PersonasAPI.Entities;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Services;

namespace PersonasAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonasController : ControllerBase
	{
		private readonly IService<PersonaDTO, long> personasService;

		public PersonasController(IService<PersonaDTO, long> personasService)
		{
			this.personasService = personasService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<List<Persona>> GetAll()
		{
			IEnumerable<PersonaDTO> personas = this.personasService.GetAll();

			if (personas.Count() == 0) { return NoContent(); }

			return Ok(personas);
		}

		[HttpGet]
		[Route("{document:long}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<PersonaDTO> GetByDocument([FromRoute] long document)
		{
			PersonaDTO persona = this.personasService.GetById(document);

			if (persona == null) { return NoContent(); }

			return Ok(persona);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<PersonaDTO> Add([FromBody] PersonaDTO persona)
		{
			if (persona == null) { return BadRequest(); }

			PersonaDTO savedPersona = this.personasService.Add(persona);

			return Ok(savedPersona);

		}

		[HttpPut]
		[Route("{document:long}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult Update([FromRoute] long document, [FromBody] PersonaDTO persona)
		{
			if (persona == null) return BadRequest();

			PersonaDTO optionalPersona = this.personasService.Update(document, persona);

			if (optionalPersona == null) { return NotFound(); }

			return Ok(optionalPersona);
		}

		[HttpDelete]
		[Route("{document:long}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult Delete([FromRoute] long document)
		{
			bool result = this.personasService.Delete(document);
			if (!result) { return NotFound(); }
			return Ok();
		}
	}
}
