using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task3.Iterators
{
    class ocIterator: IIterator
    {
        private bool isFirstRun = true;
        private VirusData currentVirus = null;
        public class simpleElemCouple
        {
            public INode node;
            public List<GenomeData> genomes = new List<GenomeData>();
        }
        private simpleElemCouple currentOC = new simpleElemCouple();
        private List<INode> nodeStore = new List<INode>();
        private List<GenomeData> genomeStore = new List<GenomeData>();
        public ocIterator(OvercomplicatedDatabase ocDB, SimpleGenomeDatabase genomeDB)
        {
            //copy paste edit the code from my previous lab file IteratorsWithoutYield.cs, use either DFS or BFS (doesn't matter). Visited flag shouldnt be needed as long
            //as the basic format of function remains the same. the flag was already mostly useless by the time I finished writing the code, just a fragment
            //of my initial idea about the solution.
            collectNodesRecursively(ocDB);
            genomeStore.AddRange(genomeDB.genomeDatas);
        }
        //private void collectNodesRecursively(OvercomplicatedDatabase ocDB)  //this function along witht he corresponding function achieves something of a mix of a DFS and a BFS tree search algorithm //should never be accessed from within itself
        //{
        //    nodeStore.Add(ocDB.Root);
        //    nodeStore.AddRange(ocDB.Root.Children);
        //    foreach(var child in ocDB.Root.Children)
        //    {
        //        collectNodesRecursively(ocDB,child);
        //    }
        //}
        private void collectNodesRecursively(OvercomplicatedDatabase ocDB)  //this function achieves a DFS tree search algorithm //should never be accessed from within itself
        {
            nodeStore.Add(ocDB.Root);
            foreach (var child in ocDB.Root.Children)
            {
                nodeStore.Add(child);
                collectNodesRecursively(ocDB, child);
            }
        }
        //private void collectNodesRecursively(OvercomplicatedDatabase ocDB, INode currentRoot)  //this function along witht he corresponding function achieves something of a mix of a DFS and a BFS tree search algorithm     //should never be accesed directly, but from the variant that only requires ocDB as argument
        //{
        //    nodeStore.AddRange(ocDB.Root.Children);
        //    foreach (var child in currentRoot.Children)
        //    {
        //        collectNodesRecursively(ocDB, child);
        //    }
        //}
        private void collectNodesRecursively(OvercomplicatedDatabase ocDB, INode currentRoot)  //this function helps achieve DFS for the corresponding function     //should never be accesed directly, but from the variant that only requires ocDB as argument
        {
            foreach (var child in currentRoot.Children)
            {
                nodeStore.Add(child);
                collectNodesRecursively(ocDB, child);
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
                currentOC = new simpleElemCouple();
                currentOC.node = nodeStore.First();
                nodeStore.RemoveAt(0);
                foreach (GenomeData genom in genomeStore)
                {
                    foreach(string tag in genom.Tags)
                    {
                        if (tag == currentOC.node.GenomeTag)
                        {
                            GenomeData genome = new GenomeData(genom.Id, genom.Tags, genom.Genome, genom.Precision);
                            currentOC.genomes.Add(genome);
                            break;
                        }
                    }
                }
                currentVirus = new VirusData(currentOC.node.VirusName, currentOC.node.DeathRate, currentOC.node.InfectionRate, currentOC.genomes);
                return currentVirus;
            }
        }

        public bool isAftertLastElement()
        {
            if (nodeStore.Count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
