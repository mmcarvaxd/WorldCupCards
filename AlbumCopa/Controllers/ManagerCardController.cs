using AlbumCopa.Classes;
using AlbumCopa.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlbumCopa.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagerCardController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ManagerCard> Get()
        {
            return StoneAgeDatabase.GetManagerCards();
        }

    }
}
