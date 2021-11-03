namespace monopoly
{
    public class StationTile : PurchasableTile
    {
        public StationTile(StationCard card, int price, int resaleValue, int loc, string name) : base (card, price, resaleValue, loc, name)
        { }

        /* Charges rent based on number of stations owned. */
        public override void ChargeRent(Player p)
        {
            StationCard c = (StationCard)_card;
            CmdTransfer.MakePayment(p, c.CalculateRent(CmdCardActions.CountCardsOfType(Owner, typeof(StationCard))), Owner);
            Board.NextPlayer();
        }
    }
}