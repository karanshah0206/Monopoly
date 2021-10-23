namespace monopoly
{
    static class CmdMove
    {
        public static void MoveToLoc(Player p, int loc, bool passGo = true)
        { p.Location = loc; ExecuteTileAction(p); }
        public static void MoveByCount(Player p, int count)
        { p.Location += count; p.Location %= 40; ExecuteTileAction(p); }
        private static void ExecuteTileAction(Player p)
        { Board.GetTile(p.Location).Execute(p); }
    }
}