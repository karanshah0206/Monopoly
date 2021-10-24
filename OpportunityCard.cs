namespace monopoly
{
    public class OpportunityCard : ICard
    {
        private string _title, _desc, _cmdString;

        public OpportunityCard(string title, string desc, string command)
        { _title = title; _desc = desc; _cmdString = command; }

        public void Execute(Player p)
        { CommandInterpreter.Execute(p, this); }

        public string Title
        { get { return _title; } }

        public string Description
        { get { return _desc; } }

        public string Command
        { get { return _cmdString; } }
    }
}