namespace monopoly
{
    public static class CmdTransfer
    {
        /* Charges money, assigns owner, delegates cards into owner's list, then next player. */
        public static void BuyProperty(Player p, PurchasableTile t)
        {
            MakePayment(p, t.Price);
            t.Owner = p;
            p.Cards.Add(t.Card);
            Board.NextPlayer();
        }

        /* Sets property owner to null and pays seller the property's valuation.
         * If property has buildables, sells them and remunerates their valuation. */
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

        /* Add money to player's account. */
        public static void AddToAccount(Player p, int amount)
        { p.Balance += amount; }

        /* Remove money from  player's account.
         * If player is bankrupt, signal player lost. */
        public static void MakePayment(Player payer, int amount)
        {
            if (!IsBankrupt(payer, amount)) { payer.Balance -= amount; }
            else Board.PlayerOut(payer, null);
        }

        /* Transfers money from  payer's account to payee's account.
         * If payer is bankrupt, signal player lost. */
        public static void MakePayment(Player payer, int amount, Player payee)
        {
            if (payer.Balance < amount && IsBankrupt(payer, amount)) Board.PlayerOut(payer, payee);
            else { MakePayment(payer, amount); AddToAccount(payee, amount); }
        }

        /* Get player's networth and check if they can afford to process a pending payment.
         * Returns false if player is not bankrupt, else returns true. */
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