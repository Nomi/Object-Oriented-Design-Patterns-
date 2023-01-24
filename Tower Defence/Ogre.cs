using System;
using Defenders;

namespace Enemies
{
    class Ogre : Enemy
    {
        public int Armor { get; }

        public Ogre(string name, int hp, int armor) : base(name, hp)
        {
            Armor = armor;
        }
        public override void Approach(IDefender defender)
        {
            int dmg = defender.Attack(this);
            if(1<dmg-Armor)
            {
                dmg= (dmg - Armor);
            }
            else
            {
                dmg = 1;
            }
            GetDamage(dmg);
        }
    }
}