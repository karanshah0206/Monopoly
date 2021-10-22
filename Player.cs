namespace monopoly
{
    class Player
    {
        private int _loc;
        private string _name;
        public Player(string name)
        { _name = name; _loc = 0; }
        public void moveToLoc(int loc, bool passGo = false)
        { _loc = loc; }
        public void moveByCount(int count)
        { _loc += count; _loc %= 40; }
        public int CurrentLocation
        { get { return _loc; } }
    }
}
