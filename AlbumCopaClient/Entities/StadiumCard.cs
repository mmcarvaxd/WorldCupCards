using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaClient.Entities
{
    public class StadiumCard : Card
    {
        public string City { get; set; }

        public string Country { get; set; }

        public int MaxCapacity { get; set; }
    }
}
