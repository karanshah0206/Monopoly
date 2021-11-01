namespace monopoly
{
    public class GoTile : Tile
    {
        private int _salary;

        public GoTile(int salary, int loc) : base(loc, "Go")
        { _salary = salary; }

        public override void Execute(Player p)
        {
            CmdTransfer.AddToAccount(p, _salary);
            Board.NextPlayer();
        }

        public void Execute(Player p, bool nextPlayer)
        {
            CmdTransfer.AddToAccount(p, _salary);
            if (nextPlayer) Board.NextPlayer();
        }
    }
}