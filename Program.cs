using System;
using System.Collections.Generic;

/*
 * TODO:
 * SidebarController (Make Relevant Changes In PurchasableTile, CMDTransfer)
 * Add Images To All Required Classes
 * IDrawable + GUI
 *
 * TODO OPTIONAL:
 * Create File Purchasables (TileFactory, PurchasableCardGenerator)
 */

namespace monopoly
{
    public class Program
    {
        public static void Main()
        {
            TileGenerator tileGenerator = new();
            Dictionary<int, Tile> tiles = tileGenerator.GenerateTiles();

            OpportunitiesDeckFactory deckGenerator = new();
            Deck chance = deckGenerator.CreateOpportunitiesDeck("Chance");
            Deck communityChest = deckGenerator.CreateOpportunitiesDeck("Community Chest");

            PlayersGenerator playersGenerator = new(1500);
            List<Player> players = playersGenerator.Execute();

            JailManager jailManager = new(players);
            Board board = new(players, tiles, chance, communityChest);
        }
    }
}