using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaClient.Entities
{
    public class PlayerCard : Card
    {
        public int ShirtNumber { get; set; }

        public int SkillNumber { get; set; }

        public int Age { get; set; }

        public int Height { get; set; } //CM

        public int Weight { get; set; }
    }
}
