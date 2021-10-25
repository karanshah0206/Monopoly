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
        { payer.Balance -= amount; }

        public static void MakePayment(Player payer, int amount, Player payee)
        {
            MakePayment(payer, amount);
            AddToAccount(payee, amount);
        }
    }
}