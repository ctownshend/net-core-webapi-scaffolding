using System;
using System.Collections.Generic;
using DAL.Models;
using DAL.Repositories.DTOs;

namespace BL.Services
{
    public interface IThingService
    {
        ThingDTO Get(int id);
        IEnumerable<ThingDTO> GetAll();
        void Add(ThingDTO thing);
        void Delete(int id);
    }
}
