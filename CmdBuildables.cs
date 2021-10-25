namespace monopoly
{
    public class CmdBuildables
    {
        public static bool BuildHouse(Player p, PropertyTile t)
        {
            if (CmdCardActions.CheckColorGroupCardsOwned(p, t.ColorGroup) && t.HouseCount < 4)
            {
                PropertyCard c = t.Card as PropertyCard;
                CmdTransfer.MakePayment(p, c.BuildableCost);
                t.HouseCount++; return true;
            }
            return false;
        }

        public static bool BuildHotel(Player p, PropertyTile t)
        {
            if (t.Owner == p && t.HouseCount == 4 && !t.HasHotel)
            {
                PropertyCard c = t.Card as PropertyCard;
                CmdTransfer.MakePayment(p, c.BuildableCost);
                t.HasHotel = true; return true;
            }
            return false;
        }

        public static int GetPlayerHouseCount(Player p)
        {
            int count = 0;
            for (int i = 0; i < 40; i++)
                if (Board.GetTile(i).GetType() == typeof(PropertyTile))
                {
                    PropertyTile t = Board.GetTile(i) as PropertyTile;
                    if (t.Owner == p) count += t.HouseCount;
                }
            return count;
        }

        public static int GetPlayerHotelCount(Player p)
        {
            int count = 0;
            for (int i = 0; i < 40; i++)
                if (Board.GetTile(i).GetType() == typeof(PropertyTile))
                {
                    PropertyTile t = Board.GetTile(i) as PropertyTile;
                    if (t.Owner == p && t.HasHotel) count++;
                }
            return count;
        }
    }
}