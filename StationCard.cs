namespace monopoly
{
    public class StationCard : PurchasableCard
    {
        public StationCard(int[] rentList, string title) : base (rentList, title)
        { }

        public int CalculateRent(Player p)
        {
            int stationCount = 0; /* CmdCard.GetStationCount(p); */
            return _rentList[stationCount - 1];
        }
    }
}