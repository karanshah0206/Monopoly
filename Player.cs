namespace monopoly
{
    class Player
    {
        private string _name;
        private int _loc, _balance;
        public Player(string name, int balance)
        { _name = name; _balance = balance; _loc = 0; }
        public void moveToLoc(int loc, bool passGo = false)
        { _loc = loc; }
        public void moveByCount(int count)
        { _loc += count; _loc %= 40; }
        public int Location
        { get { return _loc; } }
        public int Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
    }
}