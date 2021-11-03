using SplashKitSDK;

namespace monopoly
{
    public class ServiceCard : PurchasableCard
    {
        public ServiceCard(int[] rentList, string title) : base (rentList, title)
        { }

        /* Return integer rent based on number of services owned and dice value. */
        public int CalculateRent(int serviceCount, int diceValue)
        { return _rentList[serviceCount - 1] * diceValue; }

        /* Draw the card. */
        public override void Draw()
        {
            int price = CmdCardActions.GetTileByCard(this).Price;
            int resale = CmdCardActions.GetTileByCard(this).ResaleValue;
            SplashKit.FillRectangle(Color.White, 10, 190, 240, 300);
            SplashKit.DrawText(Title, Color.Black, "Roboto", 15, 30, 200);
            SplashKit.DrawLine(Color.Black, 10, 220, 250, 220);
            SplashKit.DrawText("If one utility owned: " + _rentList[0] + "x dice value.", Color.Black, "Roboto", 12, 15, 230);
            SplashKit.DrawText("If both utilities owned: " + _rentList[1] + "x dice value.", Color.Black, "Roboto", 12, 15, 250);
            SplashKit.DrawText("Price: $" + price + " | Resale: $" + resale, Color.Black, "Roboto", 12, 15, 470);
        }
    }
}