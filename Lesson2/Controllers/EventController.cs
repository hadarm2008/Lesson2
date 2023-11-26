using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace שיעור_שני.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private static int count = 2;
        private static List<Event> events = new List<Event> { new Event { Id=1, Title = "defult",Start=DateTime.Today} };
        
        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get()
        { 
            
            return events;
           
        }

       

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event newEvent)
        {   
                events.Add(new Event { Id =count, Title=newEvent.Title,Start =newEvent.Start });
            count++;
           
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event newEvent)
        {
            var ev = events.Find(ev => ev.Id == id);
            ev.Title = newEvent.Title;
            ev.Start = newEvent.Start;

        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.Id == id);
            events.Remove(eve);
        }
    }
}
