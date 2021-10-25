using System.Collections.Generic;

namespace monopoly
{
    class JailManager
    {
        private static Dictionary<Player, int> _status = new();

        public JailManager(List<Player> players)
        { foreach (Player p in players) _status.Add(p, 0); }

        public static void SendToJail(Player p)
        { _status[p] = 3; CmdMove.MoveToLoc(p, 10, false); }

        public static void DecrementSentence(Player p)
        { if (_status[p] != 0) _status[p]--; }

        public static int GetStatus(Player p)
        { return _status[p]; }
    }
}