using SplashKitSDK;

namespace monopoly
{
    class Sidebar : IDrawable
    {
        private static Board _board;
        private static int _state;
        private static ICard _currentCard;
        private static GUIController _guiController;

        public Sidebar(Board board)
        { _board = board; _guiController = GUIController.GetInstance(); }

        /* Draws the sidebar.
         * Based on current state of sidebar, dynamically changes menu options. */
        public void Draw()
        {
            SplashKit.FillRectangle(Color.LightGray, 0, 0, 300, 700);
            DrawPlayersList();
            switch (_state)
            {
                case 0: DrawEventsMenu(); break;
                case 1: DrawOpportunityMenu(); break;
                case 2: DrawPurchaseMenu(); break;
                case 3: DrawRentMenu(); break;
                case 4: DrawJailMenu(); break;
                case 5: DrawHouseMenu(); break;
                case 6: DrawHotelMenu(); break;
                case 7: DrawSellMenu(); break;
                default: break;
            }
        }

        /* Draws a list of players with their names, color, and jail sentence on sidebar. */
        private void DrawPlayersList()
        {
            SplashKit.DrawText("Players:", Color.Black, "Roboto", 15, 5, 10);
            for (int i = 0; i < _board.Players.Count; i++)
            {
                Player p = _board.Players[i];
                int jailStatus = JailManager.GetStatus(p);
                string text = p.Name + "($" + p.Balance + ")";
                Color textClr = Color.Black;

                if (jailStatus > 0) text += " (Jailed for " + jailStatus + " rounds)";
                if (p == Board.GetCurrentPlayer()) textClr = Color.Red;
                SplashKit.FillCircle(p.Color, 5, 37 + (15 * i), 3);
                SplashKit.DrawText(text, textClr, "Roboto", 12, 10, 30 + (15 * i));
            }
        }

        /* Draws menu options: Roll Dice, Sell Property, Build House, Build Hotel. */
        public static void DrawEventsMenu()
        {
            if (JailManager.GetStatus(Board.GetCurrentPlayer()) != 0) _state = 4;
            else if (Board.GetCurrentPlayer().Balance < 0) _state = 7;
            else
            {
                SplashKit.DrawText("Pick an event:", Color.Black, "Roboto", 20, 5, 160);
                new Button(Color.Yellow, "Roll Dice", 10, 190).Draw();
                new Button(Color.Yellow, "Sell Properties", 10, 230).Draw();
                new Button(Color.Yellow, "Build House", 10, 270).Draw();
                new Button(Color.Yellow, "Build Hotel", 10, 310).Draw();
                _state = 0;
            }
        }

        /* Specifies a card to be drawn and sets state to draw opportunity menu. */
        public static void DrawOpportunity(ICard card)
        { _currentCard = card; _state = 1; }

        /* Specified a card to be drawn. If property is owned,
         * sets state to draw pay rent menu. Else draws purchase menu.*/
        public static void DrawPurchasable(int type, ICard card)
        {
            _currentCard = card;
            if (type == 0) _state = 2;
            else if (type == 1) _state = 3;
        }

        /* Draws menu options: Execute. */
        private void DrawOpportunityMenu()
        {
            _currentCard.Draw();
            new Button(Color.Yellow, "Execute", 10, 500).Draw();
        }

        /* Draws menu options: Purchase Property, End Turn. */
        private void DrawPurchaseMenu()
        {
            _currentCard.Draw();
            new Button(Color.Yellow, "Purchase Property", 10, 500).Draw();
            new Button(Color.Yellow, "End Turn", 10, 540).Draw();
        }

        /* Draws menu options: Get Out Now, Skip Turn. */
        private void DrawJailMenu()
        {
            if (JailManager.GetStatus(Board.GetCurrentPlayer()) == 0) _state = 0;
            else
            {
                new Button(Color.Yellow, "Get Out Now ($200)", 10, 190).Draw();
                new Button(Color.Yellow, "Skip Turn", 10, 230).Draw();
                _state = 4;
            }
        }

        /* Draws menu options: Pay Rent. */
        private void DrawRentMenu()
        {
            _currentCard.Draw();
            new Button(Color.Yellow, "Pay Rent", 10, 500).Draw();
        }

        /* Draws build house menu. Player must select a property on which to build house.
         * Cancel button provided to end action.
         * If invalid properety selected, alert sound effect */
        public void DrawHouseMenu()
        {
            PropertyTile tile;
            SplashKit.DrawText("Select A Property", Color.Black, "Roboto", 20, 5, 160);
            new Button(Color.Yellow, "Cancel", 10, 190).Draw();
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                tile = _guiController.GetTileByClick(SplashKit.MousePosition().X, SplashKit.MousePosition().Y) as PropertyTile;
                if (tile == null) { _guiController.PlaySound("alert"); }
                else
                {
                    if (CmdBuildables.BuildHouse(Board.GetCurrentPlayer(), tile)) Board.NextPlayer();
                    else { _guiController.PlaySound("alert"); }
                }
            }
        }
        /* Draws build hotel menu. Player must select a property on which to build hotel.
         * Cancel button provided to end action.
         * If invalid properety selected, alert sound effect */
        public void DrawHotelMenu()
        {
            PropertyTile tile;
            SplashKit.DrawText("Select A Property", Color.Black, "Roboto", 20, 5, 160);
            new Button(Color.Yellow, "Cancel", 10, 190).Draw();
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                tile = _guiController.GetTileByClick(SplashKit.MousePosition().X, SplashKit.MousePosition().Y) as PropertyTile;
                if (tile == null) { _guiController.PlaySound("alert"); }
                else
                {
                    if (CmdBuildables.BuildHotel(Board.GetCurrentPlayer(), tile)) Board.NextPlayer();
                    else { _guiController.PlaySound("alert"); }
                }
            }
        }

        /* Draws sell properties menu. Player must select a property to sell.
         * Done button provided to end action (not visible unless balance is at least $0).
         * If invalid properety selected, alert sound effect */
        public static void DrawSellMenu()
        {
            _state = 7;

            bool canQuit = (Board.GetCurrentPlayer().Balance >= 0);
            PurchasableTile tile;

            SplashKit.DrawText("Select A Property To Sell", Color.Black, "Roboto", 20, 5, 160);
            if (!canQuit) SplashKit.DrawText("(Must have at least $" + 0 + ")", Color.Black, "Roboto", 12, 5, 190);
            if (canQuit) new Button(Color.Yellow, "Done", 10, 670).Draw();

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                double x = SplashKit.MousePosition().X; double y = SplashKit.MousePosition().Y;
                if (x >= 10 && x <= 160 && y >= 670 && y <= 695 && canQuit) { DrawEventsMenu(); }
                else
                {
                    tile = _guiController.GetTileByClick(x, y) as PurchasableTile;
                    if (tile == null) { _guiController.PlaySound("alert"); }
                    else
                    {
                        if (CmdTransfer.SellProperty(Board.GetCurrentPlayer(), tile)) { /* Sold Successfully */ }
                        else { _guiController.PlaySound("alert"); }
                    }
                }
            }
        }

        /* Handles actions based on the current state of sidebar and player's click coorindates. */
        public void ClickHandler(double x, double y)
        {
            switch (_state)
            {
                case 0:
                    if (x >= 10 && x <= 160 && y >= 190 && y <= 215) { _guiController.PlaySound("step"); CmdMove.MoveByCount(Board.GetCurrentPlayer(), _board.RollDice()); }
                    else if (x >= 10 && x <= 160 && y >= 230 && y <= 255) { DrawSellMenu(); }
                    else if (x >= 10 && x <= 160 && y >= 270 && y <= 295) { _state = 5; }
                    else if (x >= 10 && x <= 160 && y >= 310 && y <= 335) { _state = 6; }
                    break;
                case 1:
                    if (x >= 10 && x <= 160 && y >= 500 && y <= 525) ((OpportunityCard)_currentCard).Execute(Board.GetCurrentPlayer());
                    break;
                case 2:
                    if (x >= 10 && x <= 160 && y >= 500 && y <= 525) CmdTransfer.BuyProperty(Board.GetCurrentPlayer(), CmdCardActions.GetTileByCard(_currentCard as PurchasableCard));
                    else if (x >= 10 && x <= 160 && y >= 540 && y <= 565) Board.NextPlayer();
                    break;
                case 3:
                    if (x >= 10 && x <= 160 && y >= 500 && y <= 525)
                        CmdCardActions.GetTileByCard(_currentCard as PurchasableCard).ChargeRent(Board.GetCurrentPlayer());
                    break;
                case 4:
                    if (x >= 10 && x <= 160 && y >= 190 && y <= 215) JailManager.ReleaseNow(Board.GetCurrentPlayer());
                    else if (x >= 10 && x <= 160 && y >= 230 && y <= 255) JailManager.DecrementSentence(Board.GetCurrentPlayer());
                    break;
                case 5:
                case 6:
                    if (x >= 10 && x <= 160 && y >= 190 && y <= 215) _state = 0;
                    break;
                default: break;
            }
        }
    }
}