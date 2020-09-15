using AutoMapper;
using RefactorThis.Core.DTOs;
using RefactorThis.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorThis.DAL.Configuration
{
    public class ModelMapper : IModelMapper
    {
        public IMapper Mapper { get; private set; }

        public ModelMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
                cfg.CreateMap<ProductOption, ProductOptionDTO>().ReverseMap();
            });
            Mapper = config.CreateMapper();
        }
    }
}
