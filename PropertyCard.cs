namespace monopoly
{
    public class PropertyCard : PurchasableCard
    {
        private int _buildableCost;

        public PropertyCard(int[] rentList, int buildableCost, string title) : base (rentList, title)
        { _buildableCost = buildableCost; }

        public int CalculateRent(int houseCount, bool hasHotel)
        {
            int total = houseCount;
            if (hasHotel) total++;
            return _rentList[total];
        }
    }
}