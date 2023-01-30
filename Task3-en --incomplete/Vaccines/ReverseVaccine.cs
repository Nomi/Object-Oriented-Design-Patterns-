using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class ReverseVaccine : IVaccine
    {
        public string Immunity => "ACTGAGACAT";

        public double DeathRate => 0.05f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "ReverseVaccine";
        }

        private int uses = 0;
        public string vaccinate(Dog dog)
        {
            uses++;
            return stringInverse(Immunity);
        }

        public string vaccinate(Cat cat)
        {
            uses++;
            return "absoluteDeath";
        }

        public string vaccinate(Pig pig)
        {
            if (randomElement.NextDouble() < uses*DeathRate)
            {
                uses++;
                return "absoluteDeath";
            }
            else
            {
                uses++;
                return (Immunity + stringInverse(Immunity));
            }
        }

        private string stringInverse(string str)
        {
            string result = "";
            char[] temp = str.ToCharArray();
            Array.Reverse(temp);
            foreach (char c in temp)
            {
                result += c;
            }
            return result;
        }
    }
}
