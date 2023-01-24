using System;
using Enemies;

namespace Defenders
{
    class RatCatcher : IDefender
    {
        protected readonly string name;
        private bool hasRat;

        public RatCatcher(string name)
        {
            this.name = name;
            hasRat=false;
        }

        int IDefender.Attack(Rat e)
        {
//#if DEBUG
//            Console.WriteLine(e.GetType() + " " + e.Name + " approaches " + this.GetType() + " " + this.name + ".");
//#endif
            if (hasRat)
            {
                Console.WriteLine(this.name + " ignores " + e.Name);
                return 0;
            }
            else
            {
                Console.WriteLine(this.name + " catches " + e.Name);
                hasRat = true;
                return 99999999;        //assuming that max health is less than 99999999 then the enemy will die for sure.
            }
        }

        int IDefender.Attack(Giant e)
        {
//#if DEBUG
//            Console.WriteLine(e.GetType() + " " + e.Name + " approaches " + this.GetType() + " " + this.name + ".");
//#endif
            Console.WriteLine(this.name + " ignores " + e.Name+'.');
            return 0;
        }

        int IDefender.Attack(Ogre e)
        {
//#if DEBUG
//            Console.WriteLine(e.GetType() + " " + e.Name + " approaches " + this.GetType() + " " + this.name + ".");
//#endif
            if (!hasRat)
            {
                Console.WriteLine(this.name + " ignores " + e.Name + '.');
                return 0;
            }
            else
            {
                Console.WriteLine(this.name + " throws the rat it has on " + e.Name + " causing it to flee.");
                hasRat = false;
                return 99999999;        //assuming that max health is less than 99999999 then the enemy will die for sure.
            }
        }
    }
}