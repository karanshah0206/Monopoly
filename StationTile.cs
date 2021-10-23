namespace monopoly
{
    class StationTile : PurchasabeTile
    {
        public StationTile(/* StationCard card, */ int price, int resaleValue, int loc, string name) : base (/* card, */ price, resaleValue, loc, name)
        { }

        protected override void ChargeRent(Player p)
        { CmdTransfer.MakePayment(p, 0 /* _card.CalculateRent(this.Owner) */, this.Owner); }
    }
}