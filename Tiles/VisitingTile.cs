namespace monopoly
{
    public class VisitingTile : Tile
    {
        public VisitingTile(int loc, string name) : base (loc, name)
        { }

        /* Switch to next player's turn. */
        public override void Execute(Player p)
        { Board.NextPlayer(); }
    }
}