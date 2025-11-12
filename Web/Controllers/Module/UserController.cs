using Business.Interfaces.Implements;
using Entity.DTOs.Implements.User;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class UserController : BaseController<UserDto, UserDto>
    {
        public UserController(IUserServices services, ILogger<UserController> logger)
            : base(services, logger)
        { }
    }
}
