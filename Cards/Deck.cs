using System.Collections.Generic;

namespace monopoly
{
    public class Deck
    {
        private Stack<OpportunityCard> _deck = new();

        public Deck(List<OpportunityCard> cards)
        { foreach (OpportunityCard card in cards) _deck.Push(card); }

        /* Removes topmost card from deck and returns. */
        public OpportunityCard GetTopCard()
        { return _deck.Pop(); }

        /* Adds a card to bottom of the stack. */
        public void SendCardToBottom(OpportunityCard card)
        {
            Stack<OpportunityCard> temp = new();
            while (_deck.Count > 0) temp.Push(_deck.Pop());
            _deck.Push(card);
            while (temp.Count > 0) _deck.Push(temp.Pop());
        }
    }
}