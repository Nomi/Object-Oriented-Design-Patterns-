using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Decorators;

namespace ConsoleApplication1
{
    public class ToyDecoratorWrapper :IToy          //more like a facade than a simple wrapper. In addition, restricts to one decorator of a type wherever needed.
    {
        private IToy toy;
        private List<BaseDecorator> DecoratorsUsed = new List<BaseDecorator>();
        private List<IDance> DancesLearned = new List<IDance>();
        public ToyDecoratorWrapper(IToy itoy)
        {
            toy = itoy;
        }
        public void GiveSword()
        {
            foreach (var d in DecoratorsUsed)
            {
                if (d.GetType().Name == "SwordDecorator")
                {
                    return;
                }
            }
            toy = new SwordDecorator(toy);
            DecoratorsUsed.Add(toy as BaseDecorator);
        }

        public void GiveHelmet()
        {
            foreach (var d in DecoratorsUsed)
            {
                if (d.GetType().Name == "HelmetDecorator")
                {
                    return;
                }
            }
            toy = new HelmetDecorator(toy);
            DecoratorsUsed.Add(toy as BaseDecorator);
        }

        public void GiveDottedDress()
        {

            foreach (var d in DecoratorsUsed)
            {
                if (d.GetType().Name == "DressDecorator")
                {
                    return;
                }
            }
            toy = new DressDecorator(toy, new DottedDress());
            DecoratorsUsed.Add(toy as BaseDecorator);
        }
        public void GiveFlowerDress()
        {

            foreach (var d in DecoratorsUsed)
            {
                if (d.GetType().Name == "DressDecorator")
                {
                    return;
                }
            }
            toy = new DressDecorator(toy, new FlowerDress());
            DecoratorsUsed.Add(toy as BaseDecorator);
        }

        public void GiveScaryStorytelling()
        {
            foreach (var d in DecoratorsUsed)
            {
                if (d.GetType().Name == "scaryStorytellingDecorator" || d.GetType().Name == "jokeStorytellingDecorator")
                {
                    return;
                }
            }
            toy = new scaryStorytellingDecorator(toy);
            DecoratorsUsed.Add(toy as BaseDecorator);
        }
        public void GiveJokeStorytelling()
        {
            foreach (var d in DecoratorsUsed)
            {
                if (d.GetType().Name == "scaryStorytellingDecorator" || d.GetType().Name == "jokeStorytellingDecorator")
                {
                    return;
                }
            }
            toy = new jokeStorytellingDecorator(toy);
            DecoratorsUsed.Add(toy as BaseDecorator);
        }
        public void GiveBreakdance()
        {
            foreach (var dnc in DancesLearned)
            {
                if (dnc.GetType().Name == "breakdance")
                {
                    return;
                }
            }
            IDance dance = new breakdance();
            toy = new DanceDecorator(toy, dance);
            DecoratorsUsed.Add(toy as BaseDecorator);
            DancesLearned.Add(dance);
        }
        public void GiveSoloCapoeira()
        {
            foreach (var dnc in DancesLearned)
            {
                if (dnc.GetType().Name == "soloCapoeira")
                {
                    return;
                }
            }
            IDance dance = new soloCapoeira();
            toy = new DanceDecorator(toy, dance);
            DecoratorsUsed.Add(toy as BaseDecorator);
            DancesLearned.Add(dance);
        }
        public void GiveGangnamStyle()
        {
            foreach (var dnc in DancesLearned)
            {
                if (dnc.GetType().Name == "gangnamStyle")
                {
                    return;
                }
            }
            IDance dance = new gangnamStyle();
            toy = new DanceDecorator(toy, dance);
            DecoratorsUsed.Add(toy as BaseDecorator);
            DancesLearned.Add(dance);
        }

        public void GiveJump()
        {
            foreach (var d in DecoratorsUsed)
            {
                if (d.GetType().Name == "JumpDecorator")
                {
                    return;
                }
            }
            toy = new JumpDecorator(toy);
            DecoratorsUsed.Add(toy as BaseDecorator);
        }

        public float Cost()
        {
            return toy.Cost();
        }

        public string Summary()
        {
            return toy.Summary();
        }

        public float height()
        {
            return toy.height();
        }
    }
}
