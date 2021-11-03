namespace monopoly
{
    public class GoToJailTile : Tile
    {
        public GoToJailTile(int loc) : base(loc, "Go To Jail")
        { }

        /* Sends player to jail if jail break card not owned. Else returns jail break card.
         * Sends players to just visiting tile without remuneration while passing Go. */
        public override void Execute(Player p)
        {
            OpportunityCard c = CmdCardActions.CheckJailBreakCard(p);
            if (c == null) JailManager.SendToJail(p);
            else
            {
                p.Cards.Remove(c);
                CmdCardActions.ReturnCardToDeck(c);
                CmdMove.MoveToLoc(p, 10, false);
            }
        }
    }
}