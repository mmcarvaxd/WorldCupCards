using AlbumCopa.Classes;
using AlbumCopa.DAO;
using Microsoft.AspNetCore.Mvc;

namespace AlbumCopa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StadiumCardController : ControllerBase
    {
        // GET: /StadiumCard
        [HttpGet]
        public IEnumerable<StadiumCard> Get()
        {
            return StoneAgeDatabase.GetStadiumCards();
        }

        // GET StadiumCard/{id}
        [HttpGet("{id}")]
        public StadiumCard? GetById(int id)
        {
            return StoneAgeDatabase.GetStadiumCard(id);
        }

        // POST /StadiumCard
        [HttpPost]
        public StadiumCard Create(StadiumCard stadiumCard)
        {
            return StoneAgeDatabase.CreateStadiumCard(stadiumCard);
        }

        // PUT /StadiumCard
        [HttpPut]
        public StadiumCard Edit(StadiumCard stadiumCard)
        {
            return StoneAgeDatabase.EditStadiumCard(stadiumCard);
        }

        // DELETE /StadiumCard/{id}
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return StoneAgeDatabase.RemoveStadiumCard(id);
        }
    }
}
