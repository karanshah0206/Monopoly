using System.Collections.Generic;

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

        public static void SellBuildables(Player p, PropertyTile t)
        {
            int remuneration = 0;
            List<PropertyTile> tiles = new();

            foreach (ICard c in p.Cards)
                if (c.GetType() == typeof(PropertyCard))
                    if (((PropertyCard)c).ColorGroup.Equals(t.ColorGroup))
                        tiles.Add(CmdCardActions.GetTileByCard(c as PurchasableCard) as PropertyTile);

            foreach (PropertyTile tile in tiles)
            {
                remuneration += tile.GetBuildablesValuation();
                tile.HasHotel = false; tile.HouseCount = 0;
            }

            CmdTransfer.AddToAccount(p, remuneration);
        }

        public static int GetPlayerHouseCount(Player p)
        {
            int count = 0;
            foreach (ICard c in p.Cards)
                if (c.GetType() == typeof(PropertyCard))
                    count += ((PropertyTile)CmdCardActions.GetTileByCard(c as PropertyCard)).HouseCount;
            return count;
        }

        public static int GetPlayerHotelCount(Player p)
        {
            int count = 0;
            foreach (ICard c in p.Cards)
                if (c.GetType() == typeof(PropertyCard))
                    if (((PropertyTile)CmdCardActions.GetTileByCard(c as PropertyCard)).HasHotel) count++;
            return count;
        }
    }
}