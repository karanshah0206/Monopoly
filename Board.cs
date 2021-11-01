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

        public Board(List<Player> players, Dictionary<int, Tile> tiles, Deck chance, Deck communityChest, Bitmap image)
        {
            _tiles = tiles; _players = players;
            _currentPlayerIndex = 0; _image = image;
            _chance = chance; _communityChest = communityChest;
            _dice = GenerateDice();
        }

        public static Tile GetTile(int loc)
        {
            foreach (int key in _tiles.Keys) if (key == loc) return _tiles[key];
            return null;
        }

        public static void NextPlayer()
        {
            Sidebar.DrawEventsMenu();
            _currentPlayerIndex++;
            _currentPlayerIndex %= _players.Count;
        }

        public static Player GetCurrentPlayer()
        { return _players[_currentPlayerIndex]; }

        public static void PlayerOut(Player p, Player nominee)
        {
            foreach (ICard c in p.Cards)
            {
                nominee.Cards.Add(c);
                if (c.GetType() == typeof(PropertyCard) || c.GetType() == typeof(StationCard) || c.GetType() == typeof(ServiceCard))
                    CmdCardActions.GetTileByCard(c as PurchasableCard).Owner = nominee;
            }

            CmdTransfer.MakePayment(p, p.Balance, nominee);
            JailManager.RemovePlayer(p);
            GUIController.RemoveDrawable(p);
            _players.Remove(p);

            if (_currentPlayerIndex == _players.Count) _currentPlayerIndex = 0;
        }

        public int RollDice()
        { return _diceCount = _dice[0].Roll() + _dice[1].Roll(); }

        public static int DiceCount()
        { return _diceCount; }

        private Dice[] GenerateDice()
        {
            Dice[] dice = new Dice[2];
            dice[0] = new Dice("d1", 610, 560); dice[1] = new Dice("d2", 660, 560);
            foreach(IDrawable d in dice) GUIController.AddDrawable(d);
            return dice;
        }

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