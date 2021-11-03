namespace monopoly
{
    public static class CommandInterpreter
    {
        /* Delegates command string to specific command processor based on first word.
         * First words can include: "move", "pay", "earn", and "keep". */
        public static void Execute(Player p, OpportunityCard c)
        {
            string[] cmdString = c.Command.Split(" ");

            switch(cmdString[0])
            {
                case "move": Move(p, cmdString); CmdCardActions.ReturnCardToDeck(c); break;
                case "pay": case "earn":
                    Transaction(p, cmdString);
                    CmdCardActions.ReturnCardToDeck(c);
                    Board.NextPlayer();
                    break;
                case "keep": Keep(p, c); Board.NextPlayer(); break;
            }
        }

        /* Moves the player by count or to location based on the command string. */
        private static void Move(Player p, string[] cmdString)
        {
            if (cmdString[1] == "to")
            {
                if (cmdString.Length == 4 && cmdString[3] == "false") CmdMove.MoveToLoc(p, int.Parse(cmdString[2]), false);
                else CmdMove.MoveToLoc(p, int.Parse(cmdString[2]));
            }
            else if (cmdString[1] == "by") CmdMove.MoveByCount(p, int.Parse(cmdString[2]));
        }

        /* Makes a payment or remunerates payer based on command string. */
        private static void Transaction(Player p, string[] cmdString)
        {
            if (cmdString[0] == "earn") CmdTransfer.AddToAccount(p, int.Parse(cmdString[1]));
            else if (cmdString[0] == "pay")
            {
                if (cmdString.Length == 3)
                {
                    int damage = int.Parse(cmdString[1]) * CmdBuildables.GetPlayerHouseCount(p);
                    _ = int.Parse(cmdString[2]) * CmdBuildables.GetPlayerHotelCount(p);
                    CmdTransfer.MakePayment(p, damage);
                }
                else CmdTransfer.MakePayment(p, int.Parse(cmdString[1]));
            }
        }

        /* Stores the card into player's card list. */
        private static void Keep(Player p, OpportunityCard c)
        { CmdCardActions.AddCardToPlayer(p, c); }
    }
}