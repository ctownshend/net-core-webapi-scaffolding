using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public interface IModelMapper
    {
        IMapper Mapper { get; }
    }
}
