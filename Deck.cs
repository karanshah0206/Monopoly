using System.Collections.Generic;

namespace monopoly
{
    public class Deck
    {
        private Stack<ICard> _deck = new();

        public Deck(List<ICard> cards)
        { foreach (ICard card in cards) _deck.Push(card); }

        public ICard GetTopCard()
        { return _deck.Pop(); }

        public void SendCardToBottom(ICard card)
        {
            Stack<ICard> temp = new();
            while (_deck.Count > 0) temp.Push(_deck.Pop());
            _deck.Push(card);
            while (temp.Count > 0) _deck.Push(temp.Pop());
        }
    }
}