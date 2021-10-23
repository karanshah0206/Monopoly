namespace monopoly
{
    class VisitingTile : Tile
    {
        public VisitingTile(int loc, string name) : base (loc, name)
        { }

        public override void Execute(Player p)
        { /* No Action Needed, "Just Visiting". */ }
    }
}