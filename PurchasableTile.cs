namespace monopoly
{
    abstract class PurchasableTile : Tile
    {
        private int _price, _resaleValue;
        private Player _owner;
        protected PurchasableCard _card;

        public PurchasableTile(PurchasableCard card, int price, int resaleValue, int loc, string name) : base (loc, name)
        {
            _card = card; _owner = null;
            _price = price; _resaleValue = resaleValue;
        }

        public override void Execute(Player p)
        {
            if (_owner == null) { /* Offer Purchase -> Sidebar Controller */ }
            else if (_owner == p) { /* No consequences for owner. */ }
            else { ChargeRent(p); }
        }

        protected abstract void ChargeRent(Player p);

        public int Price
        { get { return _price; } }

        public int ResaleValue
        { get { return _resaleValue; } }

        public Player Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
    }
}