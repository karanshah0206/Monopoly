namespace monopoly
{
    public static class CmdMove
    {
        public static void MoveToLoc(Player p, int loc, bool passGo = true)
        {
            if (passGo && p.Location > loc && loc != 0) ((GoTile)Board.GetTile(0)).Execute(p, false);
            p.Location = loc; ExecuteTileAction(p);
        }

        public static void MoveByCount(Player p, int count)
        {
            if (p.Location >= (p.Location + count) % 40 && (p.Location + count) % 40 != 0) ((GoTile)Board.GetTile(0)).Execute(p, false);
            p.Location += count; p.Location %= 40; ExecuteTileAction(p);
        }

        private static void ExecuteTileAction(Player p)
        { Board.GetTile(p.Location).Execute(p); }
    }
}