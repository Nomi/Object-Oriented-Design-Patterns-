using System;
using Defenders;

namespace Enemies
{
    class Giant : Enemy
    {

        public Giant(string name, int hp) : base(name, hp)
        {
        }
        public override void Approach(IDefender defender)
        {
            int dmg = defender.Attack(this);
            GetDamage(dmg);
        }
    }
}