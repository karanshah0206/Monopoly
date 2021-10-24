using System;
using System.IO;
using System.Collections.Generic;

namespace monopoly
{
    class OpportunitiesDeckFactory
    {
        public Deck CreateOpportunitiesDeck(string deckType)
        {
            switch (deckType)
            {
                case "Chance": return CreateChanceDeck();
                case "Community Chest": return CreateCommunityChestDeck();
                default: return null;
            }
        }

        private Deck CreateCommunityChestDeck()
        {
            List<OpportunityCard> cardsList = new();
            StreamReader chance = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Monopoly\\community chest.txt");
            string ln;

            while ((ln = chance.ReadLine()) != null)
            {
                string[] s = ln.Split("|");
                cardsList.Add(new("COMMUNITY CHEST", s[0], s[1]));
            }

            return new(Shuffle(cardsList));
        }

        private Deck CreateChanceDeck()
        {
            List<OpportunityCard> cardsList = new();
            StreamReader chance = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Monopoly\\chance.txt");
            string ln;

            while ((ln = chance.ReadLine()) != null)
            {
                string[] s = ln.Split("|");
                cardsList.Add(new("CHANCE", s[0], s[1]));
            }

            return new(Shuffle(cardsList));
        }

        /* Fischer-Yates Shuffle */
        private List<OpportunityCard> Shuffle(List<OpportunityCard> list)
        {
            Random random = new();
            int count = list.Count;
            while (count > 1)
            {
                count--;
                int temp = random.Next(count + 1);
                OpportunityCard c = list[temp];
                list[temp] = list[count];
                list[count] = c;
            }
            return list;
        }
    }
}