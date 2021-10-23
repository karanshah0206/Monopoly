namespace monopoly
{
    public class StationTile : PurchasableTile
    {
        public StationTile(StationCard card, int price, int resaleValue, int loc, string name) : base (card, price, resaleValue, loc, name)
        { }

        protected override void ChargeRent(Player p)
        {
            StationCard c = (StationCard)_card;
            CmdTransfer.MakePayment(p, c.CalculateRent(this.Owner), this.Owner);
        }
    }
}