using System;
using SplashKitSDK;

namespace monopoly
{
    public class Dice : IDrawable
    {
        private int _x, _y;
        Bitmap[] _images = new Bitmap[6];
        Bitmap _currentImage;

        public Dice(string name, int x, int y)
        {
            _x = x; _y = y;
            for (int i = 0; i < 6; i++)
                _images[i] = new Bitmap(name + i, "Resources\\Sprites\\d" + (i + 1) + ".png");
            _currentImage = _images[0];
        }

        public int Roll()
        {
            int diceNo = new Random().Next(1, 7);
            _currentImage = _images[diceNo - 1];
            return diceNo;
        }

        public void Draw()
        { SplashKit.DrawBitmap(_currentImage, _x, _y); }
    }
}