using System;
using Enemies;

namespace Defenders
{
    class Archer : Warrior
    {
        private int arrows;

        public Archer(string name, int strength, int arrows) : base(name, strength)
        {
            this.arrows = arrows;
        }
        public override int Attack(Rat e)
        {
//#if DEBUG
//            Console.WriteLine(e.GetType() + " " + e.Name + " approaches " + this.GetType() + " " + this.name + ".");
//#endif
            if (arrows>0)
            {
                if (rng.NextDouble() < e.Speed / 100)
                {
                    Console.WriteLine(  this.name + " attacks " + e.Name + "but misses.");
                    return 0;
                }
                else
                {
                    arrows--;
                    Console.WriteLine(  this.name + " attacks " + e.Name + " causing " + strength + " damage.");
                    return strength;
                }
            }
            else
            {
                Console.WriteLine(  this.name + " tries attacking " + e.Name + " but doesn't have any arrows left.");
            }
            return 0;
        }

        public override int Attack(Ogre e)
        {
//#if DEBUG
//            Console.WriteLine(e.GetType() + " " + e.Name + " approaches " + this.GetType() + " " + this.name + ".");
//#endif
            if (arrows>0)
            {
                arrows--;
                Console.WriteLine(  this.name + " attacks " + e.Name + " causing " + strength + " damage.");
                return strength;
            }
            else
            {
                Console.WriteLine(  this.name + " tries attacking " + e.Name + " but doesn't have any arrows left.");
            }
            return 0;
        }

        public override int Attack(Giant e)
        {
//#if DEBUG
//            Console.WriteLine(e.GetType() + " " + e.Name + " approaches " + this.GetType() + " " + this.name + ".");
//#endif
            if (arrows>=2)
            {
                arrows -= 2;
                Console.WriteLine(  this.name + " attacks (using 2 arrows) " + e.Name + " causing " + 2*strength + " damage.");    //I was not using 2*strength earlier because I was assuming Giant takes less/half damage from single arrows?
                return 2*strength;        //I'm not using 2*strength because I'm assuming Giant takes less/half damage from single arrow?
            }
            else
            {
                Console.WriteLine(  this.name + " tries attacking " + e.Name + " but doesn't have enough arrows left.");
            }
            return 0;
        }
    }
}