namespace monopoly
{
    public class StationCard : PurchasableCard
    {
        public StationCard(int[] rentList, string title) : base (rentList, title)
        { }

        public int CalculateRent(int stationCount)
        { return _rentList[stationCount - 1]; }
    }
}