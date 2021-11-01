using System.Collections.Generic;

namespace monopoly
{
    public class TileGenerator
    {
        public Dictionary<int, Tile> GenerateTiles()
        {
            TileFactory tileFactory = new TileFactory();
            Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();

            foreach (var tile in tileFactory.CreateTiles("Opportunity")) tiles.Add(tile.Key, tile.Value);
            foreach (var tile in tileFactory.CreateTiles("Go")) tiles.Add(tile.Key, tile.Value);
            foreach (var tile in tileFactory.CreateTiles("GoToJail")) tiles.Add(tile.Key, tile.Value);
            foreach (var tile in tileFactory.CreateTiles("Tax")) tiles.Add(tile.Key, tile.Value);
            foreach (var tile in tileFactory.CreateTiles("Visiting")) tiles.Add(tile.Key, tile.Value);
            foreach (var tile in tileFactory.CreateTiles("Purchasable", new PurchasableCardGenerator().CreateCards())) tiles.Add(tile.Key, tile.Value);

            return tiles;
        }
    }
}