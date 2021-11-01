using SplashKitSDK;

namespace monopoly
{
    public class StationCard : PurchasableCard
    {
        public StationCard(int[] rentList, string title) : base (rentList, title)
        { }

        public int CalculateRent(int stationCount)
        { return _rentList[stationCount - 1]; }

        public override void Draw()
        {
            base.Draw();
            for (int i = 1; i <= _rentList.Length; i++)
                if (i == 1) SplashKit.DrawText("RENT", Color.Black, "Roboto", 12, 15, 230);
                else SplashKit.DrawText("If " + i + " Stations are owned", Color.Black, "Roboto", 12, 15, 195 + i * 35);
        }
    }
}