namespace monopoly
{
    public class OpportunityTile : Tile
    {
        public OpportunityTile(int loc, string name) : base (loc, name)
        { }

        public override void Execute(Player p)
        { /* Draw Card From Opportunity Deck + Relevant Actions -> CMDCard */ }
    }
}