using System.Collections.Generic;

namespace monopoly
{
    abstract class Tile
    {
        private int _loc;
        private string _name;
        public Tile(int loc, string name)
        { _loc = loc; _name = name; }
        public abstract void action(List<Player> players, int currentPlayerIndex, int diceValue);
        public int Location
        { get { return _loc; } }
        public string Name
        { get { return _name; } }
    }
}