using System;
using System.Collections.Generic;
using System.Text;
using Task3.Vaccines;

namespace Task3.Subjects
{
    class Pig : ISubject
    {
        public bool Alive { get; set; } = true;
        public string Immunity { get; set; } = "";
        public string ID { get; set; }
        public Pig(string id)
        {
            ID = id;
        }

        public void GetTested(VirusData virus)
        {
            if (!Alive) return;
            foreach (var genome in virus.Genomes)
            {
                if (!Immunity.Contains(genome.Genome))
                {
                    Alive = false;
                    Console.WriteLine($"Pig {ID} is dead");
                    return;
                }
            }
        }
        public void GetVaccinated(IVaccine vaccine)
        {
            if (!Alive) return;
            string result = vaccine.vaccinate(this);
            if (result.CompareTo("absoluteDeath") == 0)
            {
                Alive = false;
                Console.WriteLine($"Pig {ID} died while getting vaccinated.");
            }
            else
            {
                Immunity = result;
            }
        }
    }
}
