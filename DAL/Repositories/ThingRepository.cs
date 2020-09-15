using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.Configuration;
using DAL.Models;
using DAL.Repositories.DTOs;

namespace DAL.Repositories
{
    public class ThingRepository:IThingRepository
    {
        private MyMiscelaneousDatabaseContext _dbContext;
        private IMapper _mapper;
        public ThingRepository(IModelMapper mapper, MyMiscelaneousDatabaseContext myMiscelaneousDatabaseContext)
        {
            _dbContext = myMiscelaneousDatabaseContext;
            _mapper = mapper.Mapper;
        }

        public ThingDTO Get(int id)
        {
            var result = _dbContext.Thing.FirstOrDefault(t => t.Id == id);
            return _mapper.Map<Thing, ThingDTO>(result);
        }

        public IEnumerable<ThingDTO> GetAll()
        {
            var result = _dbContext.Thing.ToList();
            return _mapper.Map<List<Thing>, IEnumerable<ThingDTO>>(result);
        }

        public void Add(ThingDTO thing)
        {
            var thingToAdd = _mapper.Map<ThingDTO, Thing>(thing);
            _dbContext.Thing.Add(thingToAdd);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var toDelete = _dbContext.Thing.FirstOrDefault(t => t.Id == id);
            _dbContext.Thing.Remove(toDelete);
            _dbContext.SaveChanges();
        }
    }
}
