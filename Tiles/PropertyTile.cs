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

        /* Charges rent if non-owner player lands on the tile. */
        public override void ChargeRent(Player p)
        {
            PropertyCard c = (PropertyCard)_card;
            CmdTransfer.MakePayment(p, c.CalculateRent(_houseCount, _hasHotel), this.Owner);
            Board.NextPlayer();
        }

        /* Returns the valuation of buildables constructed on the property. */
        public int GetBuildablesValuation()
        {
            int valuation = 0;
            valuation += _houseCount * ((PropertyCard)_card).BuildableCost / 2;
            if (_hasHotel) valuation += ((PropertyCard)_card).BuildableCost / 2;
            return valuation;
        }

        /* Returns the valuation of tile (resaleValue + buildablesValuation) */
        public override int GetValuation()
        {
            int valuation = 0;
            valuation += ResaleValue;
            valuation += GetBuildablesValuation();
            return valuation;
        }

        /* Draw Tile's Owner Indication and Buildables */
        public override void Draw()
        {
            if (Owner != null)
            {
                base.Draw();
                if (_houseCount != 0) for (int i = 0; i < HouseCount; i++) _guiController.DrawHouse(_coords[0], _coords[1], Location, i);
                if (HasHotel) _guiController.DrawHotel(_coords[0], _coords[1], Location);
            }
        }

        public Color ColorGroup
        { get { return _clrGroup; } }

        public int HouseCount
        {
            get { return _houseCount; }
            set { if (value <= 4) _houseCount = value; }
        }

        public bool HasHotel
        {
            get { return _hasHotel; }
            set { _hasHotel = value; }
        }
    }
}