namespace monopoly
{
    class ServiceTile : PurchasableTile
    {
        public ServiceTile(/* ServiceCard card, */ int price, int resaleValue, int loc, string name) : base (/* card, */ price, resaleValue, loc, name)
        { }

        protected override void ChargeRent(Player p)
        { CmdTransfer.MakePayment(p, 0 /* _card.CalculateRent(this.Owner, Board.DiceCount()) */, this.Owner); }
    }
}