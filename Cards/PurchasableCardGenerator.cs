using System.Collections.Generic;
using SplashKitSDK;

namespace monopoly
{
    class PurchasableCardGenerator
    {
        /* Returns a list of purchasable cards.
         * Purchasable cards include property, station, and service cards. */
        public List<PurchasableCard> CreateCards()
        {
            List<PurchasableCard> cardsList = new();
            foreach (PropertyCard c in PropertyCards()) cardsList.Add(c);
            foreach (StationCard c in StationCards()) cardsList.Add(c);
            foreach (ServiceCard c in ServiceCards()) cardsList.Add(c);
            return cardsList;
        }

        /* Generates all property cards in order and returns list. */
        private List<PropertyCard> PropertyCards()
        {
            List<PropertyCard> cardsList = new();
            cardsList.Add(new(new int[] { 2, 10, 30, 90, 160, 250 }, 50,"OLD KENT ROAD", Color.Brown));
            cardsList.Add(new(new int[] { 4, 20, 60, 180, 320, 450 }, 50, "WHITECHAPEL ROAD", Color.Brown));
            cardsList.Add(new(new int[] { 6, 30, 90, 270, 400, 550 }, 50, "THE ANGEL, ISLINGTON", Color.LightBlue));
            cardsList.Add(new(new int[] { 6, 30, 90, 270, 400, 550 }, 50, "EUSTON ROAD", Color.LightBlue));
            cardsList.Add(new(new int[] { 8, 40, 100, 300, 450, 600 }, 50, "PENTONVILLE ROAD", Color.LightBlue));
            cardsList.Add(new(new int[] { 10, 50, 150, 450, 625, 750 }, 100, "PALL MALL", Color.Pink));
            cardsList.Add(new(new int[] { 10, 50, 150, 450, 625, 750 }, 100, "WHITEHALL", Color.Pink));
            cardsList.Add(new(new int[] { 12, 60, 180, 500, 700, 900 }, 100, "NORTHUMBERL'D AVENUE", Color.Pink));
            cardsList.Add(new(new int[] { 14, 70, 200, 550, 750, 950 }, 100, "BOW STREET", Color.Orange));
            cardsList.Add(new(new int[] { 14, 70, 200, 550, 750, 950 }, 100, "MARLBOROUGH STREET", Color.Orange));
            cardsList.Add(new(new int[] { 16, 80, 220, 600, 800, 1000 }, 100, "VINE STREET", Color.Orange));
            cardsList.Add(new(new int[] { 18, 90, 250, 700, 875, 1050 }, 150, "STRAND", Color.Red));
            cardsList.Add(new(new int[] { 18, 90, 250, 700, 875, 1050 }, 150, "FLEET STREET", Color.Red));
            cardsList.Add(new(new int[] { 20, 100, 300, 750, 925, 1100 }, 150, "TRAFALGAR SQUARE", Color.Red));
            cardsList.Add(new(new int[] { 22, 110, 330, 800, 975, 1150 }, 150, "LEICESTER SQUARE", Color.Yellow));
            cardsList.Add(new(new int[] { 22, 110, 330, 800, 975, 1150 }, 150, "CONVENTRY STREET", Color.Yellow));
            cardsList.Add(new(new int[] { 24, 120, 360, 850, 1025, 1200 }, 150, "PICCADILLY", Color.Yellow));
            cardsList.Add(new(new int[] { 26, 130, 390, 900, 1100, 1275 }, 200, "REGENT STREET", Color.Green));
            cardsList.Add(new(new int[] { 26, 130, 390, 900, 1100, 1275 }, 200, "OXFORD STREET", Color.Green));
            cardsList.Add(new(new int[] { 28, 150, 450, 1000, 1200, 1400 }, 200, "BOND STREET", Color.Green));
            cardsList.Add(new(new int[] { 35, 175, 500, 1100, 1300, 1500 }, 200, "PARK LANE", Color.Blue));
            cardsList.Add(new(new int[] { 35, 175, 500, 1100, 1300, 1500 }, 200, "MAYFAIR", Color.Blue));
            return cardsList;
        }

        /* Generates all station cards in order and returns list. */
        private List<StationCard> StationCards()
        {
            List<StationCard> cardsList = new();
            int[] rentList = { 25, 50, 100, 200 };
            cardsList.Add(new(rentList, "KINGS CROSS STATION"));
            cardsList.Add(new(rentList, "MARYLEBONE STATION"));
            cardsList.Add(new(rentList, "FENCHURCH ST. STATION"));
            cardsList.Add(new(rentList, "LIVERPOOL ST. STATION"));
            return cardsList;
        }

        /* Generates all service cards in order and returns list. */
        private List<ServiceCard> ServiceCards()
        {
            List<ServiceCard> cardsList = new();
            int[] rentList = { 4, 10 };
            cardsList.Add(new(rentList, "ELECTRIC COMPANY"));
            cardsList.Add(new(rentList, "WATER WORKS"));
            return cardsList;
        }
    }
}