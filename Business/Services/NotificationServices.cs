using AutoMapper;
using Business.Interfaces.Implements;
using Business.Repository;
using Data.Interfaces.IDataBasic;
using Data.Interfaces.IDataImplement;
using Entity.DTOs.Implements.Notification;
using Entity.Models.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class NotificationServices : BusinessGeneric<NotificationSelectDto, NotificationCreateDto, Notification>, INotificationServices
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationServices(INotificationRepository notificationRepository, IMapper mapper)
            : base(notificationRepository, mapper)
        {
            _notificationRepository = notificationRepository;
        }
    }
}
