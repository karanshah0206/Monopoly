using SplashKitSDK;

namespace monopoly
{
    class Sidebar : IDrawable
    {
        Board _board;

        public Sidebar(Board board)
        { _board = board; }

        public void Draw()
        {
            SplashKit.FillRectangle(Color.LightGray, 0, 0, 300, 700);
            SplashKit.DrawText("Players:", Color.Black, 5, 10);
            for (int i = 0; i < _board.Players.Count; i++)
            {
                Player p = _board.Players[i];
                int jailStatus = JailManager.GetStatus(p);
                string text = p.Name + "($" + p.Balance + ")";
                Color textClr = Color.Black;

                if (jailStatus > 0) text += " (Jailed for " + jailStatus + " rounds)";
                if (p == Board.GetCurrentPlayer()) textClr = Color.Red;
                SplashKit.DrawText(text, textClr, 10, 20 + (10 * i));
            }
        }
    }
}