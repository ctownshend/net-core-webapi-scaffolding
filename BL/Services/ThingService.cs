using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.DTOs;

namespace BL.Services
{
    public class ThingService:IThingService
    {
        private IThingRepository _thingRepository;
        public ThingService(IThingRepository thingRepository)
        {
            _thingRepository = thingRepository;
        }

        public ThingDTO Get(int id)
        {
            return _thingRepository.Get(id);
        }

        public IEnumerable<ThingDTO> GetAll()
        {
            return _thingRepository.GetAll();
        }

        public void Add(ThingDTO thing)
        {
            _thingRepository.Add(thing);
        }

        public void Delete(int id)
        {
            _thingRepository.Delete(id);
        }

    }
}
