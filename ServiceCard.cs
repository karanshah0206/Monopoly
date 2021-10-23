namespace monopoly
{
    class ServiceCard : PurchasableCard
    {
        public ServiceCard(int[] rentList, string title) : base (rentList, title)
        { }

        public int CalculateRent(Player p, int diceValue)
        {
            int serviceCount = 0; /* CmdCard.GetServiceCount(p); */
            return _rentList[serviceCount - 1] * diceValue;
        }
    }
}