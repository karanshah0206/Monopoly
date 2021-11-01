using SplashKitSDK;

namespace monopoly
{
    public class OpportunityCard : ICard
    {
        private string _title, _desc, _cmdString;

        public OpportunityCard(string title, string desc, string command)
        { _title = title; _desc = desc; _cmdString = command; }

        public void Execute(Player p)
        { CommandInterpreter.Execute(p, this); }

        public void Draw()
        {
            SplashKit.FillRectangle(Color.White, 10, 190, 240, 300);
            SplashKit.DrawText(Title, Color.Black, "Roboto", 15, 30, 200);
            SplashKit.DrawLine(Color.Black, 10, 220, 250, 220);
            if (Description.Length > 30) {
                string[] description = Description.Split(".");
                for (int i = 0; i < description.Length; i++)
                    SplashKit.DrawText(description[i], Color.Black, "Roboto", 12, 15, 230 + i * 15);
            }
            else SplashKit.DrawText(Description, Color.Black, "Roboto", 12, 15, 230);
        }

        public string Title
        { get { return _title; } }

        public string Description
        { get { return _desc; } }

        public string Command
        { get { return _cmdString; } }
    }
}