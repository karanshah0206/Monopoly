namespace monopoly
{
    public class OpportunityTile : Tile
    {
        public OpportunityTile(int loc, string name) : base (loc, name)
        { }

        public override void Execute(Player p)
        {
            if (Name == "CHANCE") CmdCardActions.Chance(p);
            if (Name == "COMMUNITY CHEST") CmdCardActions.CommunityChest(p);
        }
    }
}