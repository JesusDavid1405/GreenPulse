using Entity.DTOs.Base;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base
{
    public interface ICrudController<TGet, TCreate>
        where TGet : BaseDto
    {
        Task<ActionResult<IEnumerable<TGet>>> Get();
        Task<ActionResult<TGet>> GetById(int id);
        Task<ActionResult<TGet>> Post(TCreate dto);
        Task<ActionResult<TGet>> Put(int id, TCreate dto);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> DeleteLogic(int id);
    }
}
