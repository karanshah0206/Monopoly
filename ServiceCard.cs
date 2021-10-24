namespace monopoly
{
    public class ServiceCard : PurchasableCard
    {
        public ServiceCard(int[] rentList, string title) : base (rentList, title)
        { }

        public int CalculateRent(int serviceCount, int diceValue)
        { return _rentList[serviceCount - 1] * diceValue; }
    }
}