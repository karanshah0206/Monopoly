using System.Collections.Generic;

namespace monopoly
{
    public class Player
    {
        private string _name;
        private int _loc, _balance;
        private List<ICard> _cards;

        public Player(string name, int balance)
        { _name = name; _balance = balance; _loc = 0; }

        public void AddCard(ICard card)
        { _cards.Add(card); }

        public void RemoveCard(ICard card)
        { _cards.Remove(card); }

        public string Name
        { get { return _name; } }

        public int Location
        {
            get { return _loc; }
            set { _loc = value; }
        }

        public int Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public List<ICard> Cards
        { get { return _cards; } }
    }
}