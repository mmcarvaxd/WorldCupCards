using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaClient.Entities
{
    public class PlayerCard : Card
    {
        [JsonProperty("shirtNumber")]
        public int ShirtNumber { get; set; }

        [JsonProperty("skillNumber")]
        public int SkillNumber { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; } //CM

        [JsonProperty("weight")]
        public int Weight { get; set; }
    }
}
