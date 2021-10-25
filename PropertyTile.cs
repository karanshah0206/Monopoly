using SplashKitSDK;

namespace monopoly
{
    public class PropertyTile : PurchasableTile
    {
        private Color _clrGroup;
        private int _houseCount;
        private bool _hasHotel;

        public PropertyTile(PropertyCard card, Color clr, int price, int resaleValue, int loc, string name) : base (card, price, resaleValue, loc, name)
        {
            _clrGroup = clr;
            _houseCount = 0; _hasHotel = false;
        }

        protected override void ChargeRent(Player p)
        {
            PropertyCard c = (PropertyCard)_card;
            CmdTransfer.MakePayment(p, c.CalculateRent(_houseCount, _hasHotel), this.Owner);
        }

        public Color ColorGroup
        { get { return _clrGroup; } }

        public int HouseCount
        {
            get { return _houseCount; }
            set { if (_houseCount < 4) _houseCount = value; }
        }

        public bool HasHotel
        {
            get { return _hasHotel; }
            set { _hasHotel = value; }
        }
    }
}