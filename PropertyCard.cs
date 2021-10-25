using SplashKitSDK;

namespace monopoly
{
    public class PropertyCard : PurchasableCard
    {
        private int _buildableCost;
        private Color _clrGroup;

        public PropertyCard(int[] rentList, int buildableCost, string title, Color clrGroup) : base (rentList, title)
        { _buildableCost = buildableCost; _clrGroup = clrGroup; }

        public int CalculateRent(int houseCount, bool hasHotel)
        {
            int total = houseCount;
            if (hasHotel) total++;
            return _rentList[total];
        }

        public int BuildableCost
        { get { return _buildableCost; } }

        public Color ColorGroup
        { get { return _clrGroup; } }
    }
}