using Business.Interfaces.Implements;
using Entity.DTOs.Implements.PlantCategory;
using Entity.DTOs.Implements.SensorDevice;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class SensorDeviceController : BaseController<SensorDeviceDto, SensorDeviceDto>
    {
        public SensorDeviceController(ISensorDeviceServices services, ILogger<SensorDeviceController> logger)
            : base(services, logger)
        { }
    }
}
