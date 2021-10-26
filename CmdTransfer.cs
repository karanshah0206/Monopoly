namespace monopoly
{
    public static class CmdTransfer
    {
        public static void BuyProperty(Player p, PurchasableTile t)
        {
            MakePayment(p, t.Price);
            t.Owner = p;
            p.Cards.Add(t.Card);
        }

        public static void SellProperty(Player p, PurchasableTile t)
        {
            if (t.Owner == p)
            {
                if (t.GetType() == typeof(PropertyTile)) CmdBuildables.SellBuildables(p, t as PropertyTile);
                t.Owner = null; p.Cards.Remove(t.Card);
                AddToAccount(p, t.ResaleValue);
            }
        }

        public static void AddToAccount(Player p, int amount)
        { p.Balance += amount; }

        public static void MakePayment(Player payer, int amount)
        {
            if (payer.Balance >= amount) payer.Balance -= amount;
            else if (IsBankrupt(payer, amount)) { /* Choose Properties To Sell */ }
            else { /* Player lost. */ }
        }

        public static void MakePayment(Player payer, int amount, Player payee)
        {
            MakePayment(payer, amount);
            AddToAccount(payee, amount);
        }

        public static bool IsBankrupt(Player p, int paymentDue)
        {
            int networth = p.Balance;

            for (int i = 0; i < 40; i++)
            {
                if (Board.GetTile(i).GetType() == typeof(PropertyTile))
                {
                    PropertyTile t = Board.GetTile(i) as PropertyTile;
                    PropertyCard c = t.Card as PropertyCard;

                    if (t.Owner == p) networth += t.ResaleValue;
                    networth += (c.BuildableCost / 2) * t.HouseCount;
                    if (t.HasHotel) networth += c.BuildableCost / 2;
                }
                else if (Board.GetTile(i).GetType() == typeof(StationTile) || Board.GetTile(i).GetType() == typeof(ServiceTile))
                {
                    PurchasableTile t = Board.GetTile(i) as PurchasableTile;
                    if (t.Owner == p) networth += t.ResaleValue;
                }
            }

            if (networth < paymentDue) return true;
            return false;
        }
    }
}