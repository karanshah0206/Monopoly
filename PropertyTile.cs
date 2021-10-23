using SplashKitSDK;

namespace monopoly
{
    class PropertyTile : PurchasableTile
    {
        private Color _clrGroup;
        private int _houseCount;
        private bool _hasHotel;

        public PropertyTile(/* PropertyCard card, */ Color clr, int price, int resaleValue, int loc, string name) : base (/* card, */ price, resaleValue, loc, name)
        {
            _clrGroup = clr;
            _houseCount = 0; _hasHotel = false;
        }

        protected override void ChargeRent(Player p)
        { CmdTransfer.MakePayment(p, 0 /* _card.CalculateRent(house, hotel); */, this.Owner); }

        public Color ColorGroup
        { get { return _clrGroup; } }

        public int HouseCount
        {
            get { return _houseCount; }
            set { _houseCount = value; }
        }

        public bool HasHotel
        {
            get { return _hasHotel; }
            set { _hasHotel = value; }
        }
    }
}