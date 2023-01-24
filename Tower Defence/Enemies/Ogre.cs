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
    }
}