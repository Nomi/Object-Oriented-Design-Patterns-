using System;
using Defenders;

namespace Enemies
{
    class Rat : Enemy
    {
        public int Speed { get; private set; }

        public Rat(string name, int hp, int speed) : base(name, hp)
        {
            Speed = speed;
        }

        public override void Approach(IDefender defender)
        {
            int dmg = defender.Attack(this);
            Speed += 1; //panic
            GetDamage(dmg);
        }
    }
}