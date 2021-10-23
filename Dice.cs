using System;

namespace monopoly
{
    public class Dice
    {
        public Dice() { }

        public int Roll()
        { return new Random().Next(1, 7); }
    }
}