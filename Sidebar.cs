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
                Color textClr = Color.Black;
                if (_board.Players[i] == Board.GetCurrentPlayer()) textClr = Color.Red;
                SplashKit.DrawText(_board.Players[i].Name + " ($" + _board.Players[i].Balance + ")", textClr, 10, 20 + (10 * i));
            }
        }
    }
}