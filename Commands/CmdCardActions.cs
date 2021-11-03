using System;
using SplashKitSDK;

namespace monopoly
{
    public static class CmdCardActions
    {
        /* Adds a card to player's card list. */
        public static void AddCardToPlayer(Player p, ICard c)
        { p.AddCard(c); }

        /* Returns corresponding tile for provided puchasable card (null if invalid). */
        public static PurchasableTile GetTileByCard(PurchasableCard c)
        {
            for (int i = 0; i < 40; i++)
                if (Board.GetTile(i).GetType() == typeof(PropertyTile) || Board.GetTile(i).GetType() == typeof(ServiceTile) || Board.GetTile(i).GetType() == typeof(StationTile))
                    if (((PurchasableTile)Board.GetTile(i)).Card == c) return Board.GetTile(i) as PurchasableTile;
            return null;
        }

        /* Returns jail exemption card if owned by player, else returns null. */
        public static OpportunityCard CheckJailBreakCard(Player p)
        {
            foreach (ICard c in p.Cards) if (c.GetType() == typeof(OpportunityCard)) return c as OpportunityCard;
            return null;
        }

        /* Checks if the player is sole owner of properties under specified color group. */
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

        /* Returns int count indicating # of cards in player's list of a specified type. */
        public static int CountCardsOfType(Player p, Type type)
        {
            int count = 0;
            foreach (ICard c in p.Cards) if (c.GetType() == type) count++;
            return count;
        }

        /* Draw a card from the chance deck. */
        public static void Chance()
        { Sidebar.DrawOpportunity(Board.ChanceDeck.GetTopCard()); }

        /* Draw a card from the community chest deck. */
        public static void CommunityChest()
        { Sidebar.DrawOpportunity(Board.CommunityChestDeck.GetTopCard()); }

        /* Return a card to it's corresponding deck (chance/community chest). */
        public static void ReturnCardToDeck(OpportunityCard c)
        {
            if (c.Title == "CHANCE") Board.ChanceDeck.SendCardToBottom(c);
            else if (c.Title == "COMMUNITY CHEST") Board.CommunityChestDeck.SendCardToBottom(c);
        }
    }
}