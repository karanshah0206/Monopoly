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

        public static void SellProperty(PurchasableTile t)
        {
            Player p = t.Owner;
            if (t.GetType() == typeof(PropertyTile)) { /* Sell Buildables On All Of Colorgroup First */ }
            t.Owner = null; p.Cards.Remove(t.Card);
            AddToAccount(p, t.ResaleValue);
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