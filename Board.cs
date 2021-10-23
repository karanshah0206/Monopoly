using System.Collections.Generic;

namespace monopoly
{
    public class Board
    {
        private Dice[] _dice;
        private static List<Player> _players;
        static private Dictionary<int, Tile> _tiles;
        private static int _currentPlayerIndex, _diceCount;

        public Board(List<Player> players, Dictionary<int, Tile> tiles)
        {
            _tiles = tiles; _players = players;
            _currentPlayerIndex = 0;
            _dice = GenerateDice();
        }

        public int RollDice()
        { return _diceCount = _dice[0].Roll() + _dice[1].Roll(); }

        public static Tile GetTile(int loc)
        {
            foreach (int key in _tiles.Keys) if (key == loc) return _tiles[key];
            return null;
        }

        public static void NextPlayer()
        { _currentPlayerIndex++; _currentPlayerIndex %= _players.Count; }

        public static int DiceCount()
        { return _diceCount; }

        public static Player GetCurrentPlayer()
        { return _players[_currentPlayerIndex]; }

        private Dice[] GenerateDice()
        {
            Dice[] dice = new Dice[2];
            dice[0] = new Dice(); dice[1] = new Dice();
            return dice;
        }
    }
}