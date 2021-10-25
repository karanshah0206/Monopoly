namespace monopoly
{
    public class GoToJailTile : Tile
    {
        public GoToJailTile(int loc) : base(loc, "Go To Jail")
        { }

        public override void Execute(Player p)
        {
            OpportunityCard c = CmdCardActions.CheckJailBreakCard(p);
            if (c == null) JailManager.SendToJail(p);
            else p.Cards.Remove(c); CmdCardActions.ReturnCardToDeck(c);
        }
    }
}