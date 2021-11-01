using System.Collections.Generic;
using SplashKitSDK;

/*
 * TODO:
 * SidebarController (Make Relevant Changes In CMDTransfer)
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
            Board board = new(players, tiles, chance, communityChest, new("board", "Resources\\Sprites\\Board.png"));
            GUIController.AddDrawable(board);

            Sidebar sidebar = new(board);
            GUIController.AddDrawable(sidebar);

            new Window("Monopoly", 1000, 700);
            new Font("Roboto", "Resources\\Fonts\\Roboto-Regular.ttf");

            do
            {
                SplashKit.ProcessEvents();
                GUIController.Draw();
                if (SplashKit.MouseClicked(MouseButton.LeftButton)) sidebar.ClickHandler(SplashKit.MousePosition().X, SplashKit.MousePosition().Y);
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Monopoly"));
        }
    }
}