namespace monopoly
{
    public class CmdBuildables
    {
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
