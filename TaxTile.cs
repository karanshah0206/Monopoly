namespace monopoly
{
    public class TaxTile : Tile
    {
        private int _damage;

        public TaxTile(int damage, int loc, string name) : base (loc, name)
        { _damage = damage; }

        public override void Execute(Player p)
        { CmdTransfer.MakePayment(p, _damage); }
    }
}