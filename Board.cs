using System.Collections.Generic;
using SplashKitSDK;

namespace monopoly
{
    public class Board : IDrawable
    {
        private Dice[] _dice;
        private static List<Player> _players;
        static private Dictionary<int, Tile> _tiles;
        private static int _currentPlayerIndex, _diceCount;
        private static Deck _chance, _communityChest;
        private Bitmap _image;
        private static GUIController _guiController;

        public Board(List<Player> players, Dictionary<int, Tile> tiles, Deck chance, Deck communityChest, Bitmap image)
        {
            _guiController = GUIController.GetInstance();
            _tiles = tiles; _players = players;
            _currentPlayerIndex = 0; _image = image;
            _chance = chance; _communityChest = communityChest;
            _dice = GenerateDice();
        }

        /* Returns the Tile at a specific location. */
        public static Tile GetTile(int loc)
        {
            foreach (int key in _tiles.Keys) if (key == loc) return _tiles[key];
            return null;
        }

        /* Ends the turn of current player and starts next player's turn. */
        public static void NextPlayer()
        {
            _currentPlayerIndex++;
            _currentPlayerIndex %= _players.Count;
            Sidebar.DrawEventsMenu();
        }

        /* Returns object refernce to the player whose turn is active. */
        public static Player GetCurrentPlayer()
        { return _players[_currentPlayerIndex]; }

        /* Sells player's assets and removes them from the game. */
        public static void PlayerOut(Player p, Player nominee)
        {
            _guiController.PlaySound("lost");
            if (nominee != null)
            {
                foreach (ICard c in p.Cards)
                {
                    nominee.Cards.Add(c);
                    if (c.GetType() == typeof(PropertyCard) || c.GetType() == typeof(StationCard) || c.GetType() == typeof(ServiceCard))
                        CmdCardActions.GetTileByCard(c as PurchasableCard).Owner = nominee;
                }

                CmdTransfer.MakePayment(p, p.Balance, nominee);
            }
            else
            {
                foreach (ICard c in p.Cards)
                {
                    if (c.GetType() == typeof(OpportunityCard)) CmdCardActions.ReturnCardToDeck(c as OpportunityCard);
                    else CmdCardActions.GetTileByCard(c as PurchasableCard).Owner = null;
                }
            }

            JailManager.RemovePlayer(p);
            _guiController.RemoveDrawable(p);
            _players.Remove(p);

            if (_currentPlayerIndex == _players.Count) _currentPlayerIndex = 0;
        }

        /* Roll the dice and return the vaule. */
        public int RollDice()
        { return _diceCount = _dice[0].Roll() + _dice[1].Roll(); }

        /* Current sum of the face values on the dice. */
        public static int DiceCount()
        { return _diceCount; }

        /* Generate a pair of dice and add them to the GUI Controller's drawables list. */
        private Dice[] GenerateDice()
        {
            Dice[] dice = new Dice[2];
            dice[0] = new Dice("d1", 610, 560); dice[1] = new Dice("d2", 660, 560);
            foreach(IDrawable d in dice) _guiController.AddDrawable(d);
            return dice;
        }

        /* Draw the board on the GUI. */
        public void Draw()
        { SplashKit.DrawBitmap(_image, 300, 0); }

        public static Deck ChanceDeck
        { get { return _chance; } }

        public static Deck CommunityChestDeck
        { get { return _communityChest; } }

        public List<Player> Players
        { get { return _players; } }
    }
}