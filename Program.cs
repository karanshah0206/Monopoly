using System;
using System.Collections.Generic;

/*
 * ACTIONS:
 * Build House/Hotel (Thinking CMDBuildables, Make Relevant Changes to CMDTransfer)
 * Sell House/Hotel
 * Next Turn Management (Master Controller)
 *
 * TODO:
 * Add Images To All Required Classes
 * SidebarController (Make Relevant Changes In PurchasableTile)
 * IDrawable + GUI
 * If In Jail, Decrement Jail Sentence On Turn
 * Check For Bankruptcy in CmdTransfer MakePayment (Make It Return Bool)
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
            players.Add(new("Karan", 1500)); players.Add(new("Anchal", 1500));
            Deck chance = new OpportunitiesDeckFactory().CreateOpportunitiesDeck("Chance");
            Deck communityChest = new OpportunitiesDeckFactory().CreateOpportunitiesDeck("Community Chest");
            JailManager jailManager = new(players);
            Board board = new(players, tiles, chance, communityChest);

            PropertyTile t = Board.GetTile(1) as PropertyTile;
            t.Owner = players[0];
            t.HouseCount++;
            t.HasHotel = true;
            t = Board.GetTile(3) as PropertyTile;
            t.Owner = players[0];
            t.HasHotel = true;
            Console.WriteLine(CmdBuildables.GetPlayerHouseCount(players[0]));
            t.HouseCount++;
            Console.WriteLine(CmdBuildables.GetPlayerHouseCount(players[0]));
            t.HouseCount++;
            Console.WriteLine(CmdBuildables.GetPlayerHouseCount(players[0]));
            t.HouseCount++;
            Console.WriteLine(CmdBuildables.GetPlayerHouseCount(players[0]));
            t.HouseCount++;
            Console.WriteLine(CmdBuildables.GetPlayerHouseCount(players[0]));
            t.HouseCount++;
            Console.WriteLine(CmdBuildables.GetPlayerHouseCount(players[0]));
            Console.WriteLine(CmdBuildables.GetPlayerHotelCount(players[0]));
        }
    }
}