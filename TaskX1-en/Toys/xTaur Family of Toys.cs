using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract public class xTaur: IToy
    {
        public readonly string name="TaurMasterBB991";
        public readonly int age=10;
        public readonly float Height=100;

        public xTaur(string NAME)
        {
            name = NAME;
        }
        public xTaur(string NAME,int AGE, float HEIGHT)
        {
            name = NAME;
            age = AGE;
            Height = HEIGHT;
        }
        public float Cost()
        {
            return 250f;
        }

        public abstract string Summary();



        public float height()
        {
            return Height;
        }
    }

    public class Centaur : xTaur
    {
        public bool hasBeard=true;
        public Centaur() : base("CentaurfemKilla99102",12,100)
        {

        }
        public Centaur(string name, int age, float height,bool HasBeardd) : base(name,age,height)
        {
            hasBeard = HasBeardd;
        }

        public override string Summary()
        {
            if(hasBeard)
            {
                return $"I'm a {age}year old, BEARDED Centaur and my name is {name}.";
            }
            else
            {
                return $"I'm a {age}year old, non-bearded Centaur and my name is {name}.";
            }
        }
    }
    public class Minotaur : xTaur
    {
        public float mass=3;

        public Minotaur():base("MinotaurBeastMaster111",19, 99.99F)
        {

        }
        public Minotaur(string name, int age, float height, float MASS) : base(name, age, height)
        {
            mass = MASS;
        }

        public override string Summary()
        {
            return $"I'm a {age}year old Minotaur of mass {mass} and my name is {name}.";
        }
    }
}
