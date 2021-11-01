namespace monopoly
{
    public class ServiceTile : PurchasableTile
    {
        public ServiceTile(ServiceCard card, int price, int resaleValue, int loc, string name) : base (card, price, resaleValue, loc, name)
        { }

        public override void ChargeRent(Player p)
        {
            ServiceCard c = (ServiceCard)_card;
            CmdTransfer.MakePayment(p, c.CalculateRent(CmdCardActions.CountCardsOfType(this.Owner, typeof(ServiceCard)), Board.DiceCount()), Owner);
            Board.NextPlayer();
        }
    }
}