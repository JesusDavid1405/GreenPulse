using Business.Interfaces.Implements;
using Entity.DTOs.Implements.Notification;
using Entity.DTOs.Implements.PlantCategory;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class PlantCategoryController : BaseController<PlantCategoryDto, PlantCategoryDto>
    {
        public PlantCategoryController(IPlantCategoryServices services, ILogger<PlantCategoryController> logger)
            : base(services, logger)
        { }
    }
}
