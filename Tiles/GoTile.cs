namespace monopoly
{
    public class GoTile : Tile
    {
        private int _salary;

        public GoTile(int salary, int loc) : base(loc, "Go")
        { _salary = salary; }

        /* Moves turn to next player after remunerating current player. */
        public override void Execute(Player p)
        { Remunerate(p); Board.NextPlayer();}

        /* Remunerate player with salary. */
        public void Remunerate(Player p)
        { CmdTransfer.AddToAccount(p, _salary); }
    }
}