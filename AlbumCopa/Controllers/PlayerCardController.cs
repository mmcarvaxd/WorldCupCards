using AlbumCopa.Classes;
using AlbumCopa.DAO;
using Microsoft.AspNetCore.Mvc;

namespace AlbumCopa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerCardController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PlayerCard> Get()
        {
            return StoneAgeDatabase.GetPlayerCards();
        }

        [HttpGet("{Id}")]
        public PlayerCard? GetById(int id)
        {
            return StoneAgeDatabase.GetPlayerCard(id);
        }

        [HttpPost]
        public PlayerCard Create(PlayerCard playerCard)
        {
            return StoneAgeDatabase.CreatePlayerCard(playerCard);
        }

        [HttpPut]
        public PlayerCard Edit(PlayerCard playerCard)
        {
            return StoneAgeDatabase.EditPlayerCard(playerCard);
        }

        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            return StoneAgeDatabase.RemovePlayerCard(Id);
        }
    }
}