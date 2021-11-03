using System;
using System.Collections.Generic;

namespace monopoly
{
    class PlayersGenerator
    {
        private int _initialBalance;
        private GUIController _guiController;

        public PlayersGenerator(int initialBalance)
        {
            _initialBalance = initialBalance;
            _guiController = GUIController.GetInstance();
        }

        /* Generates 2 to 8 players and returns them in a list. */
        public List<Player> Execute()
        {
            List<Player> players = new();
            int count = GetPlayerCount();
            for (int i = 0; i < count; i++)
            {
                players.Add(GetPlayer(i + 1));
                _guiController.AddDrawable(players[i]);
            }
            return players;
        }

        /* Asks user input for number of players (validates for 2-8 players). */
        private int GetPlayerCount()
        {
            int i;
            do
            {
                Console.Clear();
                Console.Write("Enter number of players (2-8): ");
                int.TryParse(Console.ReadLine().Trim(), out i);
            } while (i > 8 || i < 2);
            return i;
        }

        /* Asks user input for each player's name (validates for non-empty strings). */
        private Player GetPlayer(int playerCount)
        {
            string name;
            do
            {
                Console.Clear();
                Console.Write("Enter Player {0}'s Name: ", playerCount);
                name = Console.ReadLine().Trim();
            } while (name == "");
            return new(name, _initialBalance, new("p" + playerCount.ToString(), "Resources\\Sprites\\p" + playerCount.ToString() + ".png"));
        }
    }
}