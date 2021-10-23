namespace monopoly
{
    public class PropertyCard : PurchasableCard
    {
        private int _houseCost, _hotelCost;

        public PropertyCard(int[] rentList, int houseCost, int hotelCost, string title) : base (rentList, title)
        { _houseCost = houseCost; _hotelCost = hotelCost; }

        public int CalculateRent(int houseCount, bool hasHotel)
        {
            int total = houseCount;
            if (hasHotel) total++;
            return _rentList[total];
        }
    }
}