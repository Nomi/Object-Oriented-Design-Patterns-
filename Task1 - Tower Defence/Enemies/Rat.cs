using System;
using Defenders;

namespace Enemies
{
    class Rat : Enemy
    {
        public int Speed { get; }

        public Rat(string name, int hp, int speed) : base(name, hp)
        {
            Speed = speed;
        }
    }
}