using System;
using System.IO;
using System.Collections.Generic;

namespace monopoly
{
    class OpportunitiesDeckFactory
    {
        /* Returns a deck based on provided string parameter ("Chance"/"Community Chest"). */
        public Deck CreateOpportunitiesDeck(string deckType)
        {
            return deckType switch
            {
                "Chance" => CreateChanceDeck(),
                "Community Chest" => CreateCommunityChestDeck(),
                _ => null,
            };
        }

        /* Creates a deck of randomly ordered community chest cards.
         * Data sourced from "community chest.txt" in Resources\Data directory. */
        private Deck CreateCommunityChestDeck()
        {
            List<OpportunityCard> cardsList = new();
            StreamReader chance = new("Resources\\Data\\community chest.txt");
            string ln;

            while ((ln = chance.ReadLine()) != null)
            {
                string[] s = ln.Split("|");
                cardsList.Add(new("COMMUNITY CHEST", s[0], s[1]));
            }

            return new(Shuffle(cardsList));
        }

        /* Creates a deck of randomly ordered chance cards.
         * Data sourced from "chance.txt" in Resources\Data directory. */
        private Deck CreateChanceDeck()
        {
            List<OpportunityCard> cardsList = new();
            StreamReader chance = new("Resources\\Data\\chance.txt");
            string ln;

            while ((ln = chance.ReadLine()) != null)
            {
                string[] s = ln.Split("|");
                cardsList.Add(new("CHANCE", s[0], s[1]));
            }

            return new(Shuffle(cardsList));
        }

        /* Fischer-Yates Shuffle used for randomizing order of cards in deck. */
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