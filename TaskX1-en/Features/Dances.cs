using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class IDance : IFeature
    {
        protected string danceName;
        public override string SummaryAdditions()
        {
            return ("I can dance "+danceName+'!');
        }
    }
    public class breakdance : IDance
    {
        public breakdance()
        {
            danceName = "breakdance";
            addlCost = 50;
        }
    }

    public class soloCapoeira : IDance
    {
        public soloCapoeira()
        {
            danceName = "solo capoeira";
            addlCost = 70;
        }
    }
    public class gangnamStyle : IDance
    {
        public gangnamStyle()
        {
            danceName = "gangnam style";
            addlCost = 100;
        }
    }
}
