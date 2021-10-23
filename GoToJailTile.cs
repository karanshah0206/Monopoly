namespace monopoly
{
    class GoToJailTile : Tile
    {
        public GoToJailTile(int loc) : base(loc, "Go To Jail")
        { }

        public override void Execute(Player p)
        {
            if (1 == 1 /* Check For Card -> CMDCard */) { /* Return Card -> CMDCard */ }
            else { /* Send To Jail */ }
        }
    }
}