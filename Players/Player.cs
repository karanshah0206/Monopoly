using System.Collections.Generic;
using SplashKitSDK;

namespace monopoly
{
    public class Player : IDrawable
    {
        private string _name;
        private int _loc, _balance;
        private List<ICard> _cards;
        private Bitmap _image; private Color _clr;
        private GUIController _guiController;

        public Player(string name, int balance, Bitmap image)
        {
            _name = name; _balance = balance;
            _loc = 0; _cards = new();
            _image = image; _guiController = GUIController.GetInstance();
            _clr = _guiController.GetPlayerColor(_image.Name);
        }

        public void AddCard(ICard card)
        { _cards.Add(card); }

        public void RemoveCard(ICard card)
        { _cards.Remove(card); }

        public void Draw()
        {
            int[] coords = _guiController.GetCoordsByTile(_loc);
            if (_image.Name.Contains('1')) { coords[1] -= 20; }
            else if (_image.Name.Contains('2')) { coords[1] -= 10; }
            else if (_image.Name.Contains('4')) { coords[1] += 10; }
            else if (_image.Name.Contains('5')) { coords[1] -= 20; coords[0] += 20; }
            else if (_image.Name.Contains('6')) { coords[1] -= 10; coords[0] += 20; }
            else if (_image.Name.Contains('7')) { coords[0] += 20; }
            else if (_image.Name.Contains('8')) { coords[1] += 10; coords[0] += 20; }
            SplashKit.DrawBitmap(_image, coords[0], coords[1]);
        }

        public string Name
        { get { return _name; } }

        public int Location
        {
            get { return _loc; }
            set { _loc = value % 40; }
        }

        public int Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public Color Color
        { get { return _clr; } }

        public List<ICard> Cards
        { get { return _cards; } }
    }
}