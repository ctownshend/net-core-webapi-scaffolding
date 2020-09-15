using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Services;
using DAL.Models;
using DAL.Repositories.DTOs;
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
        public ActionResult<ThingDTO> Get(int id)
        {
            return Ok(_thingService.Get(id));
        }

        // GET api/thing
        [HttpGet]
        public ActionResult<IEnumerable<ThingDTO>> Get()
        {
            return Ok(_thingService.GetAll());
        }

        // POST api/thing
        [HttpPost]
        public void Post([FromBody] ThingDTO thing)
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
