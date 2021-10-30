using System.Collections.Generic;
using SplashKitSDK;

namespace monopoly
{
    public class Player : IDrawable
    {
        private string _name;
        private int _loc, _balance;
        private List<ICard> _cards;
        private Bitmap _image;

        public Player(string name, int balance, Bitmap image)
        {
            _name = name; _balance = balance;
            _loc = 0; _cards = new();
            _image = image;
        }

        public void AddCard(ICard card)
        { _cards.Add(card); }

        public void RemoveCard(ICard card)
        { _cards.Remove(card); }

        public void Draw()
        {
            int[] coords = GUIController.GetCoordsByTile(_loc);
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

        public List<ICard> Cards
        { get { return _cards; } }

        public Bitmap Image
        { get { return _image; } }
    }
}