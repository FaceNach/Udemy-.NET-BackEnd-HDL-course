using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("peopleServices")] IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        { 
            var people = Repository.People.FirstOrDefault(p => p.ID == id);

            if(people == null)
            {
                return NotFound();
            }

            return Ok(people);
        } 

        [HttpGet("search/{search}")]
        public List<People> Get(string search) => Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            Repository.People.Add(people);

            return NoContent();
        }
    }

    static class Repository
    {
        public static List<People> People = new List<People>()
        {
            new People()
            {
            ID =1,
            Name = "Pedro",
            BirthDate = new DateTime(1990,12,3)
            },
            new People()
            {
                ID =2,
                Name = "Juan",
                BirthDate = new DateTime(1994,01,5)
            },
            new People()
            {
                ID = 3,
                Name = "Hector",
                BirthDate = new DateTime(1998,07,26)
            },
            new People()
            {
                ID = 4,
                Name = "Monica",
                BirthDate = new DateTime(1975, 06,3)
            }
        };
    }
    public class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; } 

    }

    
}
