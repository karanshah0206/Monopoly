using System.Collections.Generic;

namespace monopoly
{
    public class TileGenerator
    {
        /* Use Tile Factory too generate all 40 tiles on the gameboard.
         * Add purchasable tiles to drawables list. */
        public Dictionary<int, Tile> GenerateTiles()
        {
            TileFactory tileFactory = new();
            Dictionary<int, Tile> tiles = new();
            GUIController guiController = GUIController.GetInstance();

            foreach (var tile in tileFactory.CreateTiles("Opportunity")) tiles.Add(tile.Key, tile.Value);
            foreach (var tile in tileFactory.CreateTiles("Go")) tiles.Add(tile.Key, tile.Value);
            foreach (var tile in tileFactory.CreateTiles("GoToJail")) tiles.Add(tile.Key, tile.Value);
            foreach (var tile in tileFactory.CreateTiles("Tax")) tiles.Add(tile.Key, tile.Value);
            foreach (var tile in tileFactory.CreateTiles("Visiting")) tiles.Add(tile.Key, tile.Value);
            foreach (var tile in tileFactory.CreateTiles("Purchasable", new PurchasableCardGenerator().CreateCards()))
            {
                tiles.Add(tile.Key, tile.Value);
                guiController.AddDrawable(tile.Value as PurchasableTile);
            }

            return tiles;
        }
    }
}