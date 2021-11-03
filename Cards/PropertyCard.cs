using SplashKitSDK;

namespace monopoly
{
    public class PropertyCard : PurchasableCard
    {
        private int _buildableCost;
        private Color _clrGroup;

        public PropertyCard(int[] rentList, int buildableCost, string title, Color clrGroup) : base (rentList, title)
        { _buildableCost = buildableCost; _clrGroup = clrGroup; }

        /* Returns integer rent based for the card's corresponding property
         * based on the number of buildables on the property. */
        public int CalculateRent(int houseCount, bool hasHotel)
        {
            int total = houseCount;
            if (hasHotel) total++;
            return _rentList[total];
        }

        /* Draw the card. */
        public override void Draw()
        {
            base.Draw();
            SplashKit.FillRectangle(_clrGroup, 230, 190, 20, 30);
            for (int i = 0; i < _rentList.Length; i++)
                if (i == 5) SplashKit.DrawText("Rent with hotel", Color.Black, "Roboto", 12, 15, 230 + i * 35);
                else SplashKit.DrawText("Rent with " + i + " house", Color.Black, "Roboto", 12, 15, 230 + i * 35);
            SplashKit.DrawText("House Cost: $" + _buildableCost + " | Hotel Cost: $" + _buildableCost, Color.Black, "Roboto", 12, 15, 450);
        }

        public int BuildableCost
        { get { return _buildableCost; } }

        public Color ColorGroup
        { get { return _clrGroup; } }
    }
}