using AlbumCopa.Classes;

namespace AlbumCopa.DAO
{
    public static class StoneAgeDatabase
    {
        private static List<PlayerCard> PlayerCards = new List<PlayerCard>();
        private static List<StadiumCard> StadiumCards = new List<StadiumCard>();

        private static int NextId = 0;

        #region PlayerCard
        public static List<PlayerCard> GetPlayerCards()
        { 
            return PlayerCards;
        }

        public static PlayerCard? GetPlayerCard(int Id)
        {
            return PlayerCards.FirstOrDefault(p => p.CardNumber == Id);
        }

        public static PlayerCard CreatePlayerCard(PlayerCard playerCard)
        {
            playerCard.CardNumber = NextId++;

            PlayerCards.Add(playerCard);

            return playerCard;
        }

        public static bool RemovePlayerCard(int Id)
        {
            var p = GetPlayerCard(Id);

            if (p != null)
            {
                PlayerCards.Remove(p);
                return true;
            }

            return false;
        }

        public static PlayerCard EditPlayerCard(PlayerCard playerCard)
        { 
            if(RemovePlayerCard(playerCard.CardNumber))
            {
                PlayerCards.Add(playerCard);
            }

            return playerCard;
        }
        #endregion


    }
}
