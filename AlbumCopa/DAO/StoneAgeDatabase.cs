using AlbumCopa.Classes;

namespace AlbumCopa.DAO
{
    public static class StoneAgeDatabase
    {
        private static List<PlayerCard> PlayerCards { get; set; } = new List<PlayerCard>();
        private static List<StadiumCard> StadiumCards { get; set; } = new List<StadiumCard>();
        private static List<ManagerCard> ManagerCards { get; set; } = new List<ManagerCard>();


        private static int NextId = 0;

        #region PlayerCard

        public static void PopulatePlayerCards()
        {
            var players = new List<PlayerCard>
            { 
                new PlayerCard() { Description = "C. Ronaldo", Age = 37, Height = 182, ShirtNumber = 7, SkillNumber = 99, Weight = 80, CardNumber = NextId++ },
                new PlayerCard() { Description = "Messi", Age = 37, Height = 150, ShirtNumber = 30, SkillNumber = 99, Weight = 70, CardNumber = NextId++ },
                new PlayerCard() { Description = "Neymar", Age = 30, Height = 177, ShirtNumber = 10, SkillNumber = 99, Weight = 75, CardNumber = NextId++ }
            };

            PlayerCards.AddRange(players);
        }

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

        #region StadiumCard

        public static void PopulateStadiumCards()
        {

            var stadiumCards = new List<StadiumCard>
            {
                new StadiumCard() { Description = "Santiago Bernabéu", City="Madrid", Country="Espanha", MaxCapacity=81044, CardNumber = NextId++},
                new StadiumCard() { Description = "Camp Nou", City="Barcelona", Country="Espanha", MaxCapacity=99789, CardNumber = NextId++},
                new StadiumCard() { Description = "Old Trafford", City="Trafford", Country="Inglaterra", MaxCapacity=76212, CardNumber = NextId++}
            };

            StadiumCards.AddRange(stadiumCards);
        } 

        public static List<StadiumCard> GetStadiumCards()
        {
            return StadiumCards;
        }

        public static StadiumCard? GetStadiumCard(int Id)
        {
            return StadiumCards.FirstOrDefault(p => p.CardNumber == Id);
        }

        public static StadiumCard CreateStadiumCard(StadiumCard stadiumCard)
        {
            stadiumCard.CardNumber = NextId++;

            StadiumCards.Add(stadiumCard);

            return stadiumCard;
        }

        public static bool RemoveStadiumCard(int Id)
        {
            var s = GetStadiumCard(Id);

            if (s != null)
            {
                StadiumCards.Remove(s);
                return true;
            }

            return false;
        }

        public static StadiumCard EditStadiumCard(StadiumCard stadiumCard)
        {
            if (RemoveStadiumCard(stadiumCard.CardNumber))
            {
                StadiumCards.Add(stadiumCard);
            }

            return stadiumCard;
        }
        #endregion

        #region ManagerCard
        public static void PopulateManagerCards()
        {

            var managerCards = new List<ManagerCard>
            {
                new ManagerCard() { Description = "Carlo Ancelotti", Age = 63, Country="Itália", CurrentTeam = "Real Madrid", TotalTrophies = 20, CardNumber = NextId++},
                new ManagerCard() { Description = "Pep Guardiola", Age = 51, Country="Espanha", CurrentTeam = "Manchester City", TotalTrophies = 15, CardNumber = NextId++},
                new ManagerCard() { Description = "Vítor Pereira", Age = 53, Country="Portugal", CurrentTeam = "Corinthians", TotalTrophies = 10, CardNumber = NextId++},
            };

            ManagerCards.AddRange(managerCards);
        }
        public static List<ManagerCard> GetManagerCards()
        {
            return ManagerCards;
        }
        #endregion
    }
}
