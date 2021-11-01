using SplashKitSDK;

namespace monopoly
{
    class Button : IDrawable
    {
        private Color _clr;
        private string _text;
        private int _x, _y;

        public Button(Color clr, string text, int x, int y)
        {
            _clr = clr; _text = text;
            _x = x; _y = y;
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_clr, _x, _y, 150, 25);
            SplashKit.DrawText(_text, Color.Black, "Roboto", 15, _x + 10, _y + 4);
        }
    }
}