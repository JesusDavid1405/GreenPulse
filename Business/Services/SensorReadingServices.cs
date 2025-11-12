using AutoMapper;
using Business.Interfaces.Implements;
using Business.Repository;
using Data.Interfaces.IDataBasic;
using Data.Interfaces.IDataImplement;
using Entity.DTOs.Implements.SensorReading;
using Entity.Models.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SensorReadingServices : BusinessGeneric<SensorReadingSelectDto, SensorReadingCreateDto, SensorReading>, ISensorReadingServices
    {
        private readonly ISensorReadingRepository _repository;
        public SensorReadingServices(ISensorReadingRepository data,IMapper mapper)
            : base(data, mapper)
        {
            _repository = data;
        }
    }
}
