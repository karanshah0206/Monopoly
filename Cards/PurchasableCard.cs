using SplashKitSDK;

namespace monopoly
{
    public abstract class PurchasableCard : ICard
    {
        protected int[] _rentList;
        private string _title;

        public PurchasableCard(int[] rentList, string title)
        { _rentList = rentList; _title = title; }

        public string Title
        { get { return _title; } }

        public virtual void Draw()
        {
            int price = CmdCardActions.GetTileByCard(this).Price;
            int resale = CmdCardActions.GetTileByCard(this).ResaleValue;
            SplashKit.FillRectangle(Color.White, 10, 190, 240, 300);
            SplashKit.DrawText(Title, Color.Black, "Roboto", 15, 30, 200);
            SplashKit.DrawLine(Color.Black, 10, 220, 250, 220);
            for (int i = 0; i < _rentList.Length; i++) SplashKit.DrawText("$"+_rentList[i], Color.Black, "Roboto", 12, 200, 230 + i * 35);
            SplashKit.DrawText("Price: $" + price + " | Resale: $" + resale, Color.Black, "Roboto", 12, 15, 470);
        }
    }
}