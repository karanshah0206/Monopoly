namespace monopoly
{
    public abstract class Tile
    {
        private int _loc;
        private string _name;

        public Tile(int loc, string name)
        { _loc = loc; _name = name; }

        /* Actions to perform when player lands on tile. */
        public abstract void Execute(Player p);

        public int Location
        { get { return _loc; } }

        public string Name
        { get { return _name; } }
    }
}