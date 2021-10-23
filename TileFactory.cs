using System.Collections.Generic;
using SplashKitSDK;

namespace monopoly
{
    public class TileFactory
    {
        public Dictionary<int, Tile> CreateTiles(string tileType)
        {
            switch (tileType)
            {
                case "Opportunity": return CreateOpportunity();
                case "Go": return CreateGo();
                case "GoToJail": return CreateGoToJail();
                case "Tax": return CreateTax();
                case "Visiting": return CreateVisiting();
                case "Purchasable": return CreatePurchasable();
            }
            return null;
        }

        private Dictionary<int, Tile> CreateOpportunity()
        {
            Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();

            tiles.Add(2, new OpportunityTile(2, "COMMUNITY CHEST"));
            tiles.Add(7, new OpportunityTile(7, "CHANCE"));
            tiles.Add(17, new OpportunityTile(17, "COMMUNITY CHEST"));
            tiles.Add(22, new OpportunityTile(22, "CHANCE"));
            tiles.Add(33, new OpportunityTile(33, "COMMUNITY CHEST"));
            tiles.Add(36, new OpportunityTile(36, "CHANCE"));

            return tiles;
        }

        private Dictionary<int, Tile> CreateGo()
        {
            Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();
            tiles.Add(0, new GoTile(200, 0));
            return tiles;
        }

        private Dictionary<int, Tile> CreateGoToJail()
        {
            Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();
            tiles.Add(30, new GoToJailTile(30));
            return tiles;
        }

        private Dictionary<int, Tile> CreateTax()
        {
            Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();

            tiles.Add(4, new TaxTile(200, 4, "INCOME TAX"));
            tiles.Add(38, new TaxTile(100, 38, "SUPER TAX"));

            return tiles;
        }

        private Dictionary<int, Tile> CreateVisiting()
        {
            Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();

            tiles.Add(10, new VisitingTile(10, "JUST VISITING"));
            tiles.Add(20, new VisitingTile(20, "FREE PARKING"));

            return tiles;
        }

        private Dictionary<int, Tile> CreatePurchasable()
        {
            Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();

            tiles.Add(1, new PropertyTile(Color.Brown, 60, 30, 1, "OLD KENT ROAD"));
            tiles.Add(3, new PropertyTile(Color.Brown, 60, 30, 3, "WHITECHAPEL ROAD"));
            tiles.Add(5, new StationTile(200, 100, 5, "KINGS CROSS STATION"));
            tiles.Add(6, new PropertyTile(Color.LightBlue, 100, 50, 6, "THE ANGEL, ISLINGTON"));
            tiles.Add(8, new PropertyTile(Color.LightBlue, 100, 50, 8, "EUSTON ROAD"));
            tiles.Add(9, new PropertyTile(Color.LightBlue, 120, 60, 9, "PENTONVILLE ROAD"));
            tiles.Add(11, new PropertyTile(Color.Pink, 140, 70, 11, "PALL MALL"));
            tiles.Add(12, new ServiceTile(150, 75, 12, "ELECTRIC COMPANY"));
            tiles.Add(13, new PropertyTile(Color.Pink, 140, 70, 13, "WHITEHALL"));
            tiles.Add(14, new PropertyTile(Color.Pink, 160, 80, 14, "NORTHUMBERL'D AVENUE"));
            tiles.Add(15, new StationTile(200, 100, 15, "MARYLEBONE STATION"));
            tiles.Add(16, new PropertyTile(Color.Orange, 180, 90, 16, "BOW STREET"));
            tiles.Add(18, new PropertyTile(Color.Orange, 180, 90, 18, "MARLBOROUGH STREET"));
            tiles.Add(19, new PropertyTile(Color.Orange, 200, 100, 19, "VINE STREET"));
            tiles.Add(21, new PropertyTile(Color.Red, 220, 110, 21, "STRAND"));
            tiles.Add(23, new PropertyTile(Color.Red, 220, 110, 23, "FLEET STREET"));
            tiles.Add(24, new PropertyTile(Color.Red, 240, 120, 24, "TRAFALGAR SQUARE"));
            tiles.Add(25, new StationTile(200, 100, 25, "FENCHURCH ST. STATION"));
            tiles.Add(26, new PropertyTile(Color.Yellow, 260, 130, 26, "LEICESTER SQUARE"));
            tiles.Add(27, new PropertyTile(Color.Yellow, 260, 130, 27, "CONVENTRY STREET"));
            tiles.Add(28, new ServiceTile(150, 75, 28, "WATER WORKS"));
            tiles.Add(29, new PropertyTile(Color.Yellow, 280, 140, 29, "PICCADILLY"));
            tiles.Add(31, new PropertyTile(Color.Green, 300, 150, 31, "REGENT STREET"));
            tiles.Add(32, new PropertyTile(Color.Green, 300, 150, 32, "OXFORD STREET"));
            tiles.Add(34, new PropertyTile(Color.Green, 320, 160, 34, "BOND STREET"));
            tiles.Add(35, new StationTile(200, 100, 35, "LIVERPOOL ST. STATION"));
            tiles.Add(37, new PropertyTile(Color.Blue, 350, 175, 37, "PARK LANE"));
            tiles.Add(39, new PropertyTile(Color.Blue, 400, 200, 39, "MAYFAIR"));

            return tiles;
        }
    }
}