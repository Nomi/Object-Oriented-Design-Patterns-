using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class IFeature
    {
        public double addlCost;
        //public Tuple<string,int> Additions();
        public abstract string SummaryAdditions();
    }
}
