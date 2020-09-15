using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Services
{
    public interface IThingService
    {
        Thing Get(int id);
        IEnumerable<Thing> GetAll();
        void Add(Thing thing);
        void Delete(int id);
    }
}
