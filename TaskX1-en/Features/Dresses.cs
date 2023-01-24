using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //class Dresses
    //{
    //}
    public abstract class IDress:IFeature
    {

    }
    public class FlowerDress:IDress
    {
        public FlowerDress()
        {
            addlCost = 20;
        }
        public override string SummaryAdditions()
        {
            return "I have a flower dress!";
        }
    }
    public class DottedDress : IDress
    { 
        public DottedDress()
        {
            addlCost = 19.99;
        }
        public override string SummaryAdditions()
        {
            return "I have a dotted dress!";
        }
    }

}
