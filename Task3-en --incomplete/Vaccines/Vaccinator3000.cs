using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class Vaccinator3000 : IVaccine
    {
        public string Immunity => "ACTG";
        public double DeathRate => 0.1f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "Vaccinator3000";
        }
        private string calculateFinalImmunity(int repeatNumberOfTimes)
        {
            string finalImmunity = "";
            for(int i=0; i<repeatNumberOfTimes;i++)
            {
                int index = randomElement.Next(0, Immunity.Length - 1);
                finalImmunity += Immunity[index];
            }
            return finalImmunity;
        }
        public string vaccinate(Dog dog)
        {
            if (randomElement.NextDouble() < DeathRate)
            {
                return "absoluteDeath";
            }
            else
            {
                return calculateFinalImmunity(3000);
            }
        }

        public string vaccinate(Cat cat)
        {
            if (randomElement.NextDouble() < DeathRate)
            {
                return "absoluteDeath";
            }
            else
            {
                return calculateFinalImmunity(300);
            }
        }

        public string vaccinate(Pig pig)
        {
            if (randomElement.NextDouble() < 3*DeathRate)
            {
                return "absoluteDeath";
            }
            else
            {
                return calculateFinalImmunity(15);
            }
        }
    }
}
