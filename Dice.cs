using System;

namespace monopoly
{
    class Dice
    {
        public Dice() { }
        public int Roll()
        { return new Random().Next(1, 7); }
    }
}