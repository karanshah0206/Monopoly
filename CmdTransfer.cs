namespace monopoly
{
    public static class CmdTransfer
    {
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