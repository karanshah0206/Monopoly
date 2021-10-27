using System;
using System.Collections.Generic;

/*
 * TODO:
 * Add Images To All Required Classes
 * SidebarController (Make Relevant Changes In PurchasableTile, CMDTransfer)
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
            Dictionary<int, Tile> tiles = new TileGenerator().GenerateTiles();
            List<Player> players = new();
            players.Add(new("Karan", 1500)); players.Add(new("Anchal", 1500)); players.Add(new("Dhruv", 1500));
            Deck chance = new OpportunitiesDeckFactory().CreateOpportunitiesDeck("Chance");
            Deck communityChest = new OpportunitiesDeckFactory().CreateOpportunitiesDeck("Community Chest");
            JailManager jailManager = new(players);
            Board board = new(players, tiles, chance, communityChest);
            Board.NextPlayer();
            Board.NextPlayer();
            Console.WriteLine(Board.GetCurrentPlayer().Name);
            CmdTransfer.MakePayment(players[2], 1600, players[0]);
            Console.WriteLine(Board.GetCurrentPlayer().Name);
            Console.WriteLine(players[0].Balance);
        }
    }
}