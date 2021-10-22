using System.Collections.Generic;

namespace monopoly
{
    class Board
    {
        private Dice[] _dice;
        private static List<Player> _players;
        static private Dictionary<int, Tile> _tiles;
        private static int _currentPlayerIndex;
        private static int _diceCount;
        public Board(List<Player> players, Dictionary<int, Tile> tiles)
        {
            _tiles = tiles;
            _players = players;
            _currentPlayerIndex = 0;
            _dice = GenerateDice();
        }
        public void Move()
        {
            _diceCount = (_dice[0].Roll() + _dice[1].Roll()) - 1;
            Player cPlayer = _players[_currentPlayerIndex];
            CmdMove.MoveByCount(cPlayer, _diceCount);
        }
        public static Tile GetTile(int loc)
        {
            foreach (int key in _tiles.Keys) if (key == loc) return _tiles[key];
            return null;
        }
        public static void NextPlayer()
        { _currentPlayerIndex++; _currentPlayerIndex %= _players.Count; }
        private Dice[] GenerateDice()
        {
            Dice[] dice = new Dice[2];
            dice[0] = new Dice(); dice[1] = new Dice();
            return dice;
        }
        public static int DiceCount()
        { return _diceCount; }
    }
}