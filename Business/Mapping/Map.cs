using AutoMapper;
using Entity.DTOs.Implements.Notification;
using Entity.DTOs.Implements.PlantCategory;
using Entity.DTOs.Implements.PlantSpecies;
using Entity.DTOs.Implements.SensorDevice;
using Entity.DTOs.Implements.SensorReading;
using Entity.DTOs.Implements.User;
using Entity.DTOs.Implements.UserPlant;
using Entity.Models.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class Map : Profile
    {
        public Map()
        {
            // 🔹 USER
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>();

            // 🔹 AUTH
            CreateMap<User, AuthDto>().ReverseMap();
            CreateMap<AuthDto, User>();

            // 🔹 PlantCategory
            CreateMap<PlantCategory, PlantCategoryDto>().ReverseMap();

            // 🔹 PLANT SPECIES
            CreateMap<PlantSpecies, PlantSpeciesSelectDto>()
                .ForMember(dest => dest.PlantCategoryName,
                    opt => opt.MapFrom(src => src.PlantCategory != null ? src.PlantCategory.Name : string.Empty))
                .ReverseMap();

            CreateMap<PlantSpeciesCreateDto, PlantSpecies>();

            // 🔹 USER PLANT
            CreateMap<UserPlant, UserPlantSelectDto>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.User != null ? src.User.Username : string.Empty))
                .ForMember(dest => dest.PlantSpeciesCommonName,
                    opt => opt.MapFrom(src => src.PlantSpecies != null ? src.PlantSpecies.CommonName : string.Empty))
                .ForMember(dest => dest.SensorDeviceName,
                    opt => opt.MapFrom(src => src.SensorDevice != null ? src.SensorDevice.DeviceId : string.Empty))
                .ReverseMap();

            CreateMap<UserPlantCreateDto, UserPlant>();

            // 🔹 SENSOR DEVICE
            CreateMap<SensorDevice, SensorDeviceDto>()
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src =>
                        src.Status == "online" ? "En línea" :
                        src.Status == "offline" ? "Fuera de línea" : "Desconocido"))
                .ReverseMap();

            CreateMap<SensorDeviceDto, SensorDevice>();

            // 🔹 SENSOR READING
            CreateMap<SensorReading, SensorReadingSelectDto>()
                .ForMember(dest => dest.SensorDeviceName,
                    opt => opt.MapFrom(src => src.SensorDevice != null ? src.SensorDevice.Model : string.Empty))
                .ForMember(dest => dest.UserPlantNickName,
                    opt => opt.MapFrom(src => src.UserPlant != null ? src.UserPlant.Nickname : string.Empty))
                .ReverseMap();

            CreateMap<SensorReadingCreateDto, SensorReading>();

            // 🔹 NOTIFICATION
            CreateMap<Notification, NotificationSelectDto>()
                .ForMember(dest => dest.UserPlantNickname,
                    opt => opt.MapFrom(src => src.UserPlant != null ? src.UserPlant.Nickname : string.Empty))
                .ForMember(dest => dest.Level,
                    opt => opt.MapFrom(src => src.Level ?? "Info"))
                .ReverseMap();

            CreateMap<NotificationCreateDto, Notification>();
        }
    }
}
