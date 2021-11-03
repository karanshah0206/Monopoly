using System.Collections.Generic;

namespace monopoly
{
    class JailManager
    {
        private static Dictionary<Player, int> _status = new();

        public JailManager(List<Player> players)
        { foreach (Player p in players) _status.Add(p, 0); }

        /* Assigns a player 3 rounds of jail sentence, moves them to tile 10. */
        public static void SendToJail(Player p)
        { _status[p] = 3; CmdMove.MoveToLoc(p, 10, false); }

        /* Reduces the sentence of a player by 1 round. */
        public static void DecrementSentence(Player p)
        { if (_status[p] != 0) _status[p]--; Board.NextPlayer(); }

        /* Abolishes sentence for a player at the cost of $200. */
        public static void ReleaseNow(Player p)
        { _status[p] = 0; CmdTransfer.MakePayment(p, 200); }

        /* Gets the remaining sentence of a player. */
        public static int GetStatus(Player p)
        { return _status[p]; }

        /* Removes a player from the jail manager's list of players. */
        public static void RemovePlayer(Player p)
        { _status.Remove(p); }
    }
}