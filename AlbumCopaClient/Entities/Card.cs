using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaClient.Entities
{
    public abstract class Card
    {
        [JsonProperty("cardNumber")]
        public int CardNumber { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
