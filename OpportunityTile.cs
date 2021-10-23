namespace monopoly
{
    class OpportunityTile : Tile
    {
        /* Deck _oppDeck; */
        public OpportunityTile(/*Deck d,*/ int loc, string name) : base (loc, name)
        { /* _oppDeck = d; */ }

        public override void Execute(Player p)
        { /* Draw Card Fro Deck + Relevant Actions -> CMDCard */ }
    }
}