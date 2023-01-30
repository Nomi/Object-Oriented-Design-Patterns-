using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3.Iterators
{
    class simpleIterator : IIterator
    {
        private bool isFirstRun = true;
        private VirusData currentVirus = null;
        public class simpleElemCouple
        {
            public SimpleDatabaseRow row = new SimpleDatabaseRow();
            //public GenomeData genomeData;
            public List<GenomeData> genomes = new List<GenomeData>();
        }
        private simpleElemCouple currentSimple= new simpleElemCouple();
        private List<SimpleDatabaseRow> rowsStore= new List<SimpleDatabaseRow>();
        private List<GenomeData> genomeStore = new List<GenomeData>();
        public simpleIterator(SimpleDatabase simpleDB, SimpleGenomeDatabase genomeDB)
        {
            rowsStore.AddRange(simpleDB.Rows);
            genomeStore.AddRange(genomeDB.genomeDatas);
        }
        public VirusData next()             //takes the iterator to next element, but also returns the next element for extra functionality.
        {
            if (isFirstRun)
            {
                isFirstRun = false;
            }
            if (isAftertLastElement())
            {
                return null;
            }
            else       //I dind't really need an else here because of the return statement above but it doesn't hurt to be cautious for future modifications or help with understanding of the program
            {
                currentSimple.row = new SimpleDatabaseRow();
                currentSimple.row=rowsStore.First();
                rowsStore.RemoveAt(0);
                currentSimple.genomes = new List<GenomeData>();
                foreach (GenomeData genom in genomeStore)
                {
                    if (genom.Id == currentSimple.row.GenomeId)
                    {
                        GenomeData genome = new GenomeData(genom.Id, genom.Tags, genom.Genome, genom.Precision);
                        currentSimple.genomes.Add(genome);
                        continue;
                        //break;
                    }
                }

                currentVirus  = new VirusData(currentSimple.row.VirusName, currentSimple.row.DeathRate, currentSimple.row.InfectionRate, currentSimple.genomes);
                return currentVirus;
            }     
        }

        public bool isAftertLastElement()
        {
            if (rowsStore.Count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public VirusData getCurrent()
        {
            if (isFirstRun)
            {
                isFirstRun = false;
                next();
            }
            return currentVirus;
        }
    }
}
