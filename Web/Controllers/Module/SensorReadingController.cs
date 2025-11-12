using Business.Interfaces.Implements;
using Entity.DTOs.Implements.PlantCategory;
using Entity.DTOs.Implements.SensorReading;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class SensorReadingController : BaseController<SensorReadingSelectDto, SensorReadingCreateDto>
    {
        public SensorReadingController(ISensorReadingServices services, ILogger<SensorReadingController> logger)
            : base(services, logger)
        { }
    }
}
