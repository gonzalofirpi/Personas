using Microsoft.AspNetCore.Mvc;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Services;

namespace PersonasAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AutosController : ControllerBase
	{
		private readonly IService<AutoDTO, string> autosService;

		public AutosController(IService<AutoDTO, string> autosService)
		{
			this.autosService = autosService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult GetAll()
		{
			IEnumerable<AutoDTO> autos = this.autosService.GetAll();

			if (autos.Count() == 0) { return NoContent(); }

			return Ok(autos);
		}

		[HttpGet]
		[Route("{patente}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<AutoDTO> GetById([FromRoute] string patente)
		{
			AutoDTO auto = this.autosService.GetById(patente);

			if (auto == null) { return NoContent(); }

			return Ok(auto);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<AutoDTO> Add([FromBody] AutoDTO auto)
		{
			if (auto == null) return BadRequest();

			return Ok(this.autosService.Add(auto));

		}

		[HttpPut]
		[Route("{patente}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<AutoDTO> Update([FromRoute] string patente, [FromBody] AutoDTO auto)
		{
			if (auto == null) return BadRequest();

			AutoDTO optionalAuto = this.autosService.Update(patente, auto);

			if (optionalAuto == null) { return NotFound(); }

			return Ok(optionalAuto);
		}

		[HttpDelete]
		[Route("{patente}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult Delete(string patente)
		{
			bool result = this.autosService.Delete(patente);

			if (!result) return NotFound();

			return Ok();
		}
	}
}
