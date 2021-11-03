using SplashKitSDK;

namespace monopoly
{
    public abstract class PurchasableTile : Tile, IDrawable
    {
        private int _price, _resaleValue;
        private Player _owner;
        protected GUIController _guiController;
        protected PurchasableCard _card;
        protected int[] _coords;

        public PurchasableTile(PurchasableCard card, int price, int resaleValue, int loc, string name) : base (loc, name)
        {
            _card = card; _owner = null;
            _price = price; _resaleValue = resaleValue;
            _guiController = GUIController.GetInstance();
            SetCoordinates();
        }

        /* Executes specific actions when player lands on property.
         * If property owned, charge rent.
         * Else offer purchase via sidebar. */
        public override void Execute(Player p)
        {
            if (_owner == null) { Sidebar.DrawPurchasable(0, _card); }
            else if (_owner == p) { Board.NextPlayer(); }
            else { Sidebar.DrawPurchasable(1, _card); }
        }

        /* Returns the resaleVale of the tile. */
        public virtual int GetValuation()
        { return _resaleValue; }

        public abstract void ChargeRent(Player p);

        /* Draws owner indicator on tile if not null. */
        public virtual void Draw()
        {
            if (_owner != null)
            {
                SplashKit.DrawRectangle(Color.Black, _coords[0] - 1, _coords[1] - 1, 12, 12);
                SplashKit.FillRectangle(_owner.Color, _coords[0], _coords[1], 10, 10);
            }
        }

        /* Calculates coordinates for drawing items on tile based on location. */
        private void SetCoordinates()
        {
            _coords = _guiController.GetCoordsByTile(Location);
            if (Location > 0 && Location < 10) { _coords[0] -= 5; _coords[1] += 24; }
            else if (Location > 10 && Location < 20) { _coords[0] -= 13; _coords[1] -= 22; }
            else if (Location > 20 && Location < 30) { _coords[0] += 34; _coords[1] = 1; }
            else if (Location > 30 && Location < 40) { _coords[0] += 39; _coords[1] += 27; }
        }

        public int Price
        { get { return _price; } }

        public int ResaleValue
        { get { return _resaleValue; } }

        public Player Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public PurchasableCard Card
        { get { return _card; } }
    }
}