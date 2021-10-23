namespace monopoly
{
    class Player
    {
        private string _name;
        private int _loc, _balance;
        public Player(string name, int balance)
        { _name = name; _balance = balance; _loc = 0; }
        public string Name
        { get { return _name; } }
        public int Location
        {
            get { return _loc; }
            set { _loc = value; }
        }
        public int Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
    }
}