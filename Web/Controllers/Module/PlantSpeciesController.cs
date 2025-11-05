using Business.Interfaces.Implements;
using Entity.DTOs.Implements.PlantCategory;
using Entity.DTOs.Implements.PlantSpecies;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class PlantSpeciesController : BaseController<PlantSpeciesSelectDto, PlantSpeciesCreateDto>
    {
        public PlantSpeciesController(IPlantSpeciesServices services, ILogger<PlantSpeciesController> logger)
            : base(services, logger)
        { }
    }
}
