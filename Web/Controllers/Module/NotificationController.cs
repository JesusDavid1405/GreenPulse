using Business.Interfaces.IBusinessBasic;
using Business.Interfaces.Implements;
using Entity.DTOs.Implements.Notification;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class NotificationController : BaseController<NotificationSelectDto, NotificationCreateDto>
    {
        public NotificationController(INotificationServices service, ILogger<NotificationController> logger)
            : base(service, logger)
        { }
    }
}
