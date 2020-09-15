using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {
        private IThingService _thingService;

        public ThingController(IThingService thingService)
        {
            _thingService = thingService;
        }


        // GET api/thing/5
        [HttpGet("{id}")]
        public ActionResult<Thing> Get(int id)
        {
            return Ok(_thingService.Get(id));
        }

        // GET api/thing
        [HttpGet]
        public ActionResult<IEnumerable<Thing>> Get()
        {
            return Ok(_thingService.GetAll());
        }

        // POST api/thing
        [HttpPost]
        public void Post([FromBody] Thing thing)
        {
            _thingService.Add(thing);
        }

        // DELETE api/thing/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _thingService.Delete(id);
        }
    }
}
