using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;

namespace ConsoleApplication1.Decorators
{
    //public enum additions { sword, helmet, }
    public class BaseDecorator: IToy
    {
        //private List(Tuple<IToy, Type>) keyValuePairs;
        protected IToy wrapee=null;
        //bool dressAlreadyWorn = false;
        protected IToy getUndecoratedToy()
        {
            if (wrapee.GetType().IsSubclassOf(this.GetType()))
            {
                return getUndecoratedToy();
            }
            else
            {
                return wrapee;
            }
        }
        public BaseDecorator(IToy wrapii)
        {
            wrapee = wrapii;
        }
        public virtual float Cost()
        {
            return wrapee.Cost();
        }

        public float height()
        {
            return wrapee.height();
        }

        public virtual string Summary()
        {
            return wrapee.Summary();
        }
    }

    public class SwordDecorator : BaseDecorator
    {
        public SwordDecorator(IToy wrapii):base(wrapii)
        {

        }
        public override float Cost()
        {
            return wrapee.Cost() + 15;
        }
        public override string Summary()
        {
            return wrapee.Summary() + " I have a sword!";
        }
    }

    public class HelmetDecorator : BaseDecorator
    {
        public HelmetDecorator(IToy wrapii) : base(wrapii)
        {

        }
        public override float Cost()
        {
            return wrapee.Cost() + 10;
        }
        public override string Summary()
        {
            return wrapee.Summary() + " I have a helmet on my head!";
        }
    }

    public class DressDecorator:BaseDecorator
    {
        IDress dress;
        public DressDecorator(IToy wrapii,IDress drs) : base(wrapii)
        {
            dress = drs;
        }
        public override float Cost()
        {
            //if (dressWornAlready)
            //    return wrapee.Cost();
            //else
                return wrapee.Cost() + (float)dress.addlCost;
        }
        public override string Summary()
        {
            //if (dressWornAlready)
            //    return wrapee.Summary();
            //else
                return wrapee.Summary() + ' ' +dress.SummaryAdditions();
        }
    }
    public class DanceDecorator : BaseDecorator
    {
        IDance dance;
        public DanceDecorator(IToy wrapii, IDance dnc) : base(wrapii)
        {
            dance = dnc;
        }
        public override float Cost()
        {
            return wrapee.Cost() + (float)dance.addlCost;
        }
        public override string Summary()
        {
            return wrapee.Summary() + ' ' + dance.SummaryAdditions();
        }
    }

    public class JumpDecorator : BaseDecorator
    {
        private float jumpHeightRatio=0.5F;
        private float jhrStep = -0.1F;
        public JumpDecorator(IToy wrapii) : base(wrapii)
        {
        }
        public override float Cost()
        {
            return wrapee.Cost() + 20;
        }
        public override string Summary()
        {
            if(jumpHeightRatio>=0.1)
            {
                string ToReturn = wrapee.Summary() + ' ' + $"I can jump! I just jumped  {(decimal)(jumpHeightRatio * base.height())}cm!"; //{(jumpHeightRatio * base.height()).ToString("0.00")}
                jumpHeightRatio += jhrStep;
                return ToReturn;
            }
            else
            {
                return wrapee.Summary()+string.Empty;
            }
        }
    }


    public class scaryStorytellingDecorator : BaseDecorator
    {
        public scaryStorytellingDecorator(IToy wrapii) : base(wrapii)
        {

        }
        public override float Cost()
        {
            return wrapee.Cost() + 30;
        }
        public override string Summary()
        {
            return wrapee.Summary() + " I tell scary stories!";
        }
    }
    public class jokeStorytellingDecorator : BaseDecorator
    {
        public jokeStorytellingDecorator(IToy wrapii) : base(wrapii)
        {

        }
        public override float Cost()
        {
            return wrapee.Cost() + 30;
        }
        public override string Summary()
        {
            return wrapee.Summary() + " I tell really funny jokes!";
        }
    }
}
