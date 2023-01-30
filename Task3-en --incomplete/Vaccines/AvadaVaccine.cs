using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;


namespace Task3.Vaccines
{
    class AvadaVaccine : IVaccine
    {
        public string Immunity => "ACTAGAACTAGGAGACCA";

        public double DeathRate => 0.2f;

        private Random randomElement = new Random(0);

        public override string ToString()
        {
            return "AvadaVaccine";
        }

        public string vaccinate(Dog dog)
        {
            return Immunity;
        }

        public string vaccinate(Cat cat)
        {
            if (randomElement.NextDouble()<DeathRate)
            {
                return "absoluteDeath";
            }
            else
            {
                return Immunity.Remove(0,3);
            }
        }

        public string vaccinate(Pig pig)
        {
            return "absoluteDeath";
        }
    }
}
