namespace monopoly
{
    public class OpportunityCard : ICard
    {
        private OpportunityCommand _command;
        private string _title, _desc, _cmdString;

        public OpportunityCard(string title, string desc, string command)
        {
            _title = title; _desc = desc;
            _cmdString = command;
            _command = new OpportunityCommand();
        }

        public void Execute(Player p)
        { _command.Execute(p, _cmdString.Split(" ")); }

        public string Title
        { get { return _title; } }

        public string Description
        { get { return _desc; } }
    }
}