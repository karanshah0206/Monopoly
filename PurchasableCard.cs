namespace monopoly
{
    public abstract class PurchasableCard : ICard
    {
        protected int[] _rentList;
        private string _title;

        public PurchasableCard(int[] rentList, string title)
        { _rentList = rentList; _title = title; }

        public string Title
        { get { return _title; } }
    }
}