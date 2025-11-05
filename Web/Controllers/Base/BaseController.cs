using Business.Interfaces.IBusinessBasic;
using Entity.DTOs.Base;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class BaseController<TGet, TCreate> : ControllerBase, ICrudController<TGet, TCreate>
        where TGet : BaseDto
    {
        protected readonly IBusinessBasic<TGet, TCreate> Service;
        protected readonly ILogger Logger;

        protected BaseController(IBusinessBasic<TGet, TCreate> service, ILogger logger)
        {
            Service = service;
            Logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<IEnumerable<TGet>>> Get()
            => Ok(await Service.GetAllAsync());

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TGet>> GetById(int id)
            => await Service.GetByIdAsync(id) is { } dto ? Ok(dto) : NotFound();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<TGet>> Post([FromBody] TCreate dto)
        {
            var created = await Service.CreateAsync(dto);

            // Respuesta 201 con Location al recurso usando Id del DTO base
            if (created.Id > 0)
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

            // Devolver 200 si por algún motivo no se asignó Id (casos especiales)
            return Ok(created);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TGet>> Put(int id, [FromBody] TCreate dto)
        {
            if (dto is BaseDto withId && withId.Id != 0 && withId.Id != id)
                return BadRequest("El ID del cuerpo no coincide con el ID de la URL.");

            if (dto is BaseDto baseDto)
                baseDto.Id = id;

            var updated = await Service.UpdateAsync(dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Delete(int id)
            => await Service.DeleteAsync(id) ? NoContent() : NotFound();

        [HttpPatch("{id:int}/soft-delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> DeleteLogic(int id)
            => await Service.DeleteLogicAsync(id) ? NoContent() : NotFound();
    }
}
