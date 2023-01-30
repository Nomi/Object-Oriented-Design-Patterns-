using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task3.Iterators
{
    class excelIterator :IIterator
    {
        private bool isFirstRun = true;
        private VirusData currentVirus=null;
        public class simpleElemCouple
        {
            public SimpleDatabaseRow row = new SimpleDatabaseRow();
            public List<GenomeData> genomes = new List<GenomeData>();
        }
        private simpleElemCouple currentExcel=new simpleElemCouple();
        private List<SimpleDatabaseRow> rowsStore = new List<SimpleDatabaseRow>();
        private List<GenomeData> genomeStore = new List<GenomeData>();
        public excelIterator(ExcellDatabase excelDB, SimpleGenomeDatabase genomeDB)
        {
            currentExcel.genomes.AddRange(genomeDB.genomeDatas);
            System.Globalization.NumberFormatInfo formatInfo = new System.Globalization.NumberFormatInfo();
            formatInfo.NumberDecimalSeparator = ".";
            formatInfo.NumberGroupSeparator = ",";
            string[] names=null; string[] infectionRates = null; string[] deathRates = null; string[] genomeIDs = null;
            parseXlStrings(ref excelDB, ref names, ref infectionRates, ref deathRates, ref genomeIDs);
            int tempCount1 = 0;
            foreach (var n in names)
            {
                currentExcel.row = new SimpleDatabaseRow();
                currentExcel.row.VirusName = n;  //names[tempCount1];
                currentExcel.row.InfectionRate = Convert.ToDouble(infectionRates[tempCount1], formatInfo);
                currentExcel.row.DeathRate = Convert.ToDouble(deathRates[tempCount1], formatInfo);
                currentExcel.row.GenomeId = Guid.Parse(genomeIDs[tempCount1]);
                rowsStore.Add(currentExcel.row);
                tempCount1++;
            }
            genomeStore.AddRange(genomeDB.genomeDatas);
        }
        private void parseXlStrings(ref ExcellDatabase excelDB, ref string[] names, ref string[] infectionRates, ref string[] deathRates, ref string[] genomeIDs)
        {
            names = excelDB.Names.Split(new char[] { ';' });
            deathRates = excelDB.DeathRates.Split(new char[] { ';' });
            infectionRates = excelDB.InfectionRates.Split(new char[] { ';' });
            genomeIDs = excelDB.GenomeIds.Split(new char[] { ';' });
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
            else
            {
                currentExcel.row = rowsStore.First();
                rowsStore.RemoveAt(0);
                currentExcel.genomes = new List<GenomeData>();

                foreach (GenomeData genom in genomeStore)
                {
                    if (genom.Id == currentExcel.row.GenomeId)
                    {
                        GenomeData genome = new GenomeData(genom.Id, genom.Tags, genom.Genome, genom.Precision);
                        currentExcel.genomes.Add(genome);
                        continue;
                    }
                }

                currentVirus = new VirusData(currentExcel.row.VirusName, currentExcel.row.DeathRate, currentExcel.row.InfectionRate, currentExcel.genomes);
                return currentVirus;
            }
        }

        public bool isAftertLastElement()
        {
            if (rowsStore.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
