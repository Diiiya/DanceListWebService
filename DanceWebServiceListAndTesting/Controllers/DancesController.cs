using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanceWebServiceListAndTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DancesController : ControllerBase
    {
        private static List<Dance> _dances;
        private static int _nextId;

        static DancesController()
        {
            Initialize();
        }

        // For testing
        public void ReInitialize() { Initialize(); }

        private static void Initialize()
        {
            _dances = new List<Dance>();
            Dance d1 = new Dance { Id = 1, Name = "Salsa", Description = "A popular socian dance which origins can be found in the Cuban folk dances.", Photo = "", Country = "Cuba", TimeAppeared = 1800, Type = "Latino", AddedDate = new DateTime() };
            Dance d2 = new Dance { Id = 2, Name = "Bachata", Description = "Slow social dance coming from the Dominican Republic.", Photo = "", Country = "Dominican Republic", TimeAppeared = 1960, Type = "Latino", AddedDate = new DateTime() };
            Dance d3 = new Dance { Id = 3, Name = "Lindy Hop", Description = "Lindy hop is another social dance. It's a mix of many dances such as jazz, tap, Charleston.", Photo = "", Country = "New York City", TimeAppeared = 1928, Type = "Swing", AddedDate = new DateTime() };
            _dances.Add(d1);
            _dances.Add(d2);
            _dances.Add(d3);
            _nextId = 4;
        }


        // GET: api/Dances
        [HttpGet]
        public IEnumerable<Dance> Get()
        {
            return _dances;
        }

        // GET: api/Dances/5
        [HttpGet("{id}", Name = "Get")]
        public Dance Get(int id)
        {
            return _dances.FirstOrDefault(Dance => Dance.Id == id);
        }

        // POST: api/Dances
        [HttpPost]
        public Dance Post([FromBody] Dance value)
        {
            value.Id = _nextId;
            _nextId++;
            _dances.Add(value);
            return value;
        }

        // PUT: api/Dances/5
        [HttpPut("{id}")]
        public Dance Put(int id, [FromBody] Dance value)
        {
            Dance dance = _dances.FirstOrDefault(student => student.Id == id);
            if (dance == null) return null;
            dance.Name = value.Name;
            dance.Description = value.Description;
            dance.Photo = value.Photo;
            dance.Country = value.Country;
            dance.TimeAppeared = value.TimeAppeared;
            dance.Type = value.Type;
            dance.AddedDate = value.AddedDate;
            return dance;

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int howMany = _dances.RemoveAll(dance => dance.Id == id);
            return howMany;

        }
    }
}
