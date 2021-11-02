namespace monopoly
{
    public static class CmdTransfer
    {
        public static void BuyProperty(Player p, PurchasableTile t)
        {
            MakePayment(p, t.Price);
            t.Owner = p;
            p.Cards.Add(t.Card);
            Board.NextPlayer();
        }

        public static bool SellProperty(Player p, PurchasableTile t)
        {
            if (t.Owner == p)
            {
                if (t.GetType() == typeof(PropertyTile)) CmdBuildables.SellBuildables(p, t as PropertyTile);
                t.Owner = null; p.Cards.Remove(t.Card);
                AddToAccount(p, t.ResaleValue);
                return true;
            }
            return false;
        }

        public static void AddToAccount(Player p, int amount)
        { p.Balance += amount; }

        public static void MakePayment(Player payer, int amount)
        {
            if (!IsBankrupt(payer, amount)) { payer.Balance -= amount; }
            else Board.PlayerOut(payer, null);
        }

        public static void MakePayment(Player payer, int amount, Player payee)
        {
            if (payer.Balance < amount && IsBankrupt(payer, amount)) Board.PlayerOut(payer, payee);
            else { MakePayment(payer, amount); AddToAccount(payee, amount); }
        }

        public static bool IsBankrupt(Player p, int paymentDue)
        {
            int networth = p.Balance;

            foreach (ICard c in p.Cards)
            {
                if (c.GetType() == typeof(PropertyCard) || c.GetType() == typeof(StationCard) || c.GetType() == typeof(ServiceCard))
                {
                    PurchasableTile t = CmdCardActions.GetTileByCard(c as PurchasableCard);
                    networth += t.GetValuation();
                }
            }

            if (networth < paymentDue) return true;
            return false;
        }
    }
}