﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaClient.Core
{
    public static class UriPaths
    {
        public static Uri ApiUrl = new Uri("https://localhost:7235/");

        public static Uri PlayerCard = new Uri(ApiUrl, "PlayerCard");

        public static Uri StadiumCard = new Uri(ApiUrl, "StadiumCard");

        public static Uri DeletePlayerCard(int id) => new Uri(ApiUrl, $"PlayerCard/{id}");
        public static Uri DeleteStadiumCard(int id) => new Uri(ApiUrl, $"StadiumCard/{id}");
    }
}
