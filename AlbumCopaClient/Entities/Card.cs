using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaClient.Entities
{
    public abstract class Card
    {
        public int CardNumber { get; set; }

        public string Description { get; set; }
    }
}
