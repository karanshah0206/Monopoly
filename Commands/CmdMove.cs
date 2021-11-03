namespace monopoly
{
    public static class CmdMove
    {
        /* Move player directly to a location, execute action based on tile.
         * Parameter passGo indicates if salary should be provided on passing Go. */
        public static void MoveToLoc(Player p, int loc, bool passGo = true)
        {
            if (passGo && p.Location > loc && loc != 0) ((GoTile)Board.GetTile(0)).Remunerate(p);
            p.Location = loc; ExecuteTileAction(p);
        }

        /* Increment player's location based on count, execute action based on tile. */
        public static void MoveByCount(Player p, int count)
        {
            if (p.Location >= (p.Location + count) % 40 && (p.Location + count) % 40 != 0) ((GoTile)Board.GetTile(0)).Remunerate(p);
            p.Location += count; p.Location %= 40; ExecuteTileAction(p);
        }

        /* Execute tile's action on the player. */
        private static void ExecuteTileAction(Player p)
        { Board.GetTile(p.Location).Execute(p); }
    }
}