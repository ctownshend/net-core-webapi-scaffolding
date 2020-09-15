using AutoMapper;
using DAL.Models;
using DAL.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class ModelMapper : IModelMapper
    {
        public IMapper Mapper { get; private set; }

        public ModelMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Thing, ThingDTO>().ReverseMap();
            });
            Mapper = config.CreateMapper();
        }
    }
}
