using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaClient.Entities
{
    public class ManagerCard : Card
    {
        public int Age { get; set; }
        public string CurrentTeam { get; set; }
        public int TotalTrophies { get; set; }
        public string Country { get; set; }
    }
}
