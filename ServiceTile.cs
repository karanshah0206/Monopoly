namespace monopoly
{
    public class ServiceTile : PurchasableTile
    {
        public ServiceTile(ServiceCard card, int price, int resaleValue, int loc, string name) : base (card, price, resaleValue, loc, name)
        { }

        protected override void ChargeRent(Player p)
        {
            ServiceCard c = (ServiceCard)_card;
            CmdTransfer.MakePayment(p, c.CalculateRent(1 /* CmdCard.GetServiceCount(this.Owner) */, Board.DiceCount()), this.Owner);
        }
    }
}