using System.Collections.Generic;
using SplashKitSDK;

/*
 * TODO:
 * Sidebar -> Sound When Unable To Build
 * Draw House/Hotel
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
            Board board = new(players, tiles, chance, communityChest, new("board", "Resources\\Sprites\\Board.png"));
            Sidebar sidebar = new(board);

            GUIController guiController = GUIController.GetInstance();
            guiController.AddDrawable(board);
            guiController.AddDrawable(sidebar);

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