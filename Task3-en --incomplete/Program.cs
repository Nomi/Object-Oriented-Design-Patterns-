using System;
using System.Collections.Generic;
using Task3.Subjects;
using Task3.Vaccines;
using Task3.Iterators;

namespace Task3
{
    class Program
    {
        public class MediaOutlet
        {
            public void Publish()
            {
                SimpleGenomeDatabase simpleGenomeDatabase = Generators.PrepareGenomes();
                SimpleDatabase simpleDatabase = Generators.PrepareSimpleDatabase(simpleGenomeDatabase);
                ExcellDatabase excellDatabase = Generators.PrepareExcellDatabase(simpleGenomeDatabase);
                OvercomplicatedDatabase overcomplicatedDatabase = Generators.PrepareOvercomplicatedDatabase(simpleGenomeDatabase);

                IIterator itr;
                itr = new simpleIterator(simpleDatabase, simpleGenomeDatabase);
                Publish(itr);
                itr = new excelIterator(excellDatabase, simpleGenomeDatabase);
                Publish(itr);
                itr = new ocIterator(overcomplicatedDatabase, simpleGenomeDatabase);
                Publish(itr);

            }
            public void Publish(IIterator itr)
            {
                while (!itr.isAftertLastElement())
                {
                    //VirusData virusData = itr.getCurrent();
                    //itr.next();
                    VirusData virusData = itr.next();
                    Console.WriteLine(virusData.ToString());
                }
                //while (!itr.isAftertLastElement())
                //{
                //    VirusData virusData = itr.next();
                //    Console.WriteLine(virusData.ToString());
                //}
            }
        }

        public class Tester
        {
            public void Test()
            {
                var vaccines = new List<IVaccine>() { new AvadaVaccine(), new Vaccinator3000(), new ReverseVaccine() };

                foreach (var vaccine in vaccines)
                {
                    Console.WriteLine($"Testing {vaccine}");
                    var subjects = new List<ISubject>();
                    int n = 5;
                    for (int i = 0; i < n; i++)
                    {
                        subjects.Add(new Cat($"{i}"));
                        subjects.Add(new Dog($"{i}"));
                        subjects.Add(new Pig($"{i}"));
                    }

                    foreach (var subject in subjects)
                    {
                        subject.GetVaccinated(vaccine);
                    }

                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    // iteration over SimpleGenomeDatabase using solution from 1)
                    // subjects should be tested here using GetTested function
                    simpleIterator itrVirus = new simpleIterator(simpleDatabase, genomeDatabase);
                    foreach (var subject in subjects)
                    {
                        while (!itrVirus.isAftertLastElement())
                        {
                            subject.GetTested(itrVirus.next());
                        }
                    }
                    // iterating over simpleDatabase
                    //{
                    //foreach (var subject in subjects)
                    //{
                    //    subject.GetTested();
                    //}
                    //}

                    int aliveCount = 0;
                    foreach (var subject in subjects)
                    {
                        if (subject.Alive) aliveCount++;
                    }
                    Console.WriteLine($"{aliveCount} alive!");
                }
            }
        }
        public static void Main(string[] args)
        {
            var genomeDatabase = Generators.PrepareGenomes();
            var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
            var excellDatabase = Generators.PrepareExcellDatabase(genomeDatabase);
            var overcomplicatedDatabase = Generators.PrepareOvercomplicatedDatabase(genomeDatabase);
            var mediaOutlet = new MediaOutlet();

            ///
            ///stage 1:
            ///
            //mediaOutlet.Publish(); //publishes everything
            ///or///
            IIterator itr;
            itr = new simpleIterator(simpleDatabase, genomeDatabase);
            mediaOutlet.Publish(itr);
            itr = new excelIterator(excellDatabase, genomeDatabase);
            mediaOutlet.Publish(itr);
            itr = new ocIterator(overcomplicatedDatabase, genomeDatabase);
            mediaOutlet.Publish(itr);


            ///
            ///stage 2:
            ///
                    //skipping for now.


            ///
            ///stage 4 (and 3):
            ///
            // testing animals
            var tester = new Tester();
            tester.Test();
        }
    }
}
