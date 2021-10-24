namespace monopoly
{
    public class CmdCardActions
    {
        public static void AddCardToPlayer(Player p, ICard c)
        { p.AddCard(c); }

        public static OpportunityCard CheckJailBreakCard(Player p)
        {
            foreach (ICard c in p.Cards) if (c.GetType() == typeof(OpportunityCard)) return c as OpportunityCard;
            return null;
        }

        public static int GetPlayerHouseCount(Player p)
        { return 0; /* Add Logic */ }

        public static int GetPlayerHotelCount(Player p)
        { return 0; /* Add Logic */ }

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