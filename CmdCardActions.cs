using System;
using SplashKitSDK;

namespace monopoly
{
    public class CmdCardActions
    {
        public static void AddCardToPlayer(Player p, ICard c)
        { p.AddCard(c); }

        public static PurchasableTile GetTileByCard(PurchasableCard c)
        {
            for (int i = 0; i < 40; i++)
                if (Board.GetTile(i).GetType() == typeof(PropertyTile) || Board.GetTile(i).GetType() == typeof(ServiceTile) || Board.GetTile(i).GetType() == typeof(StationTile))
                    if (((PurchasableTile)Board.GetTile(i)).Card == c) return Board.GetTile(i) as PurchasableTile;
            return null;
        }

        public static OpportunityCard CheckJailBreakCard(Player p)
        {
            foreach (ICard c in p.Cards) if (c.GetType() == typeof(OpportunityCard)) return c as OpportunityCard;
            return null;
        }

        public static bool CheckColorGroupCardsOwned(Player p, Color clr)
        {
            int count = 0;
            foreach(ICard c in p.Cards)
                if (c.GetType() == typeof(PropertyCard))
                {
                    PropertyCard card = c as PropertyCard;
                    if (card.ColorGroup.Equals(clr)) count++;
                }
            if ((clr.Equals(Color.Brown) || clr.Equals(Color.Blue)) && count == 2) return true;
            else if (count == 3) return true;
            return false;
        }

        public static int CountCardsOfType(Player p, Type type)
        {
            int count = 0;
            foreach (ICard c in p.Cards) if (c.GetType() == type) count++;
            return count;
        }

        public static void Chance(Player p)
        { Board.ChanceDeck.GetTopCard().Execute(p); }

        public static void CommunityChest(Player p)
        { Board.CommunityChestDeck.GetTopCard().Execute(p); }

        public static void ReturnCardToDeck(OpportunityCard c)
        {
            if (c.Title == "CHANCE") Board.ChanceDeck.SendCardToBottom(c);
            else if (c.Title == "COMMUNITY CHEST") Board.CommunityChestDeck.SendCardToBottom(c);
        }
    }
}