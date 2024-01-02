using Microsoft.AspNetCore.Mvc;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Services;

namespace PersonasAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpresasController : ControllerBase
	{
		private readonly IService<EmpresaDTO, int> empresasService;

		public EmpresasController(IService<EmpresaDTO, int> empresasService)
		{
			this.empresasService = empresasService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<EmpresaDTO>> GetAll()
		{
			IEnumerable<EmpresaDTO> empresas = this.empresasService.GetAll();

			if (empresas.Count() == 0) return NoContent();

			return Ok(empresas);
		}

		[HttpGet]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<EmpresaDTO> GetById([FromRoute] int id)
		{
			EmpresaDTO optionalEmpresa = this.empresasService.GetById(id);

			if (optionalEmpresa == null) return NotFound();

			return Ok(optionalEmpresa);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<EmpresaDTO> Add([FromBody] EmpresaDTO empresaDTO)
		{
			if (empresaDTO == null || empresaDTO.Dirección == null) return BadRequest();

			EmpresaDTO savedEmpresa = this.empresasService.Add(empresaDTO);

			return Ok(savedEmpresa);
		}

		[HttpPut]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<EmpresaDTO> Update([FromRoute] int id, [FromBody] EmpresaDTO empresaDTO)
		{
			if (empresaDTO == null) return BadRequest();

			EmpresaDTO optionalEmpresa = this.empresasService.Update(id, empresaDTO);

			if (optionalEmpresa == null) return NotFound();

			return Ok(optionalEmpresa);
		}

		[HttpDelete]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult Delete([FromRoute] int id)
		{
			bool result = this.empresasService.Delete(id);

			if (!result) return NotFound();

			return Ok();
		}
	}
}
