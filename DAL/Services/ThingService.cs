using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Services
{
    public class ThingService:IThingService
    {
        private MyMiscelaneousDatabaseContext _dbContext;
        public ThingService(MyMiscelaneousDatabaseContext myMiscelaneousDatabaseContext)
        {
            _dbContext = myMiscelaneousDatabaseContext;
        }

        public Thing Get(int id)
        {
            return _dbContext.Thing.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Thing> GetAll()
        {
            return _dbContext.Thing.ToList();
        }

        public void Add(Thing thing)
        {
            _dbContext.Thing.Add(thing);
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
