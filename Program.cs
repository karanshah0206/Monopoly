/* Monopoly: A GUI-Based Digital Monopoly Game For 2-8 Players
 * Name: Karan Manoj Shah | Student ID: 103141481
 * Unit: COS20007 Object Oriented Programming
 * Semester 2 2021 | Swinburne University of Technology */

using System.Collections.Generic;
using SplashKitSDK;

namespace monopoly
{
    public class Program
    {
        public static void Main()
        {
            /* Generate Tiles & Associated Cards */
            TileGenerator tileGenerator = new();
            Dictionary<int, Tile> tiles = tileGenerator.GenerateTiles();
            /* Generate Opportunity Card Decks */
            OpportunitiesDeckFactory deckGenerator = new();
            Deck chance = deckGenerator.CreateOpportunitiesDeck("Chance");
            Deck communityChest = deckGenerator.CreateOpportunitiesDeck("Community Chest");
            /* Generate Players */
            PlayersGenerator playersGenerator = new(1500);
            List<Player> players = playersGenerator.Execute();
            /* Initialize Jail Manager, Gameboard, and Sidebar */
            JailManager jailManager = new(players);
            Board board = new(players, tiles, chance, communityChest, new("board", "Resources\\Sprites\\Board.png"));
            Sidebar sidebar = new(board);
            /* Get Instance of Singleton GUI Controller */
            GUIController guiController = GUIController.GetInstance();
            guiController.AddDrawable(board);
            guiController.AddDrawable(sidebar);
            /* SplashKit Window & Font Settings */
            new Window("Monopoly", 1000, 700);
            new Font("Roboto", "Resources\\Fonts\\Roboto-Regular.ttf");

            do
            {
                SplashKit.ProcessEvents();
                guiController.Draw();
                if (SplashKit.MouseClicked(MouseButton.LeftButton)) sidebar.ClickHandler(SplashKit.MousePosition().X, SplashKit.MousePosition().Y);
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Monopoly"));
        }
    }
}