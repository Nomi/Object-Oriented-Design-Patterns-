using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Decorators;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------------TESTS (using ToyDecoratorWrapper for simplification)---------------------");
            Console.WriteLine("COST"+ "||||" + "HEIGHT"+ "||||" + "SUMMARY");
            Console.ResetColor();
            IToy ty1 = new Minotaur();
            ToyDecoratorWrapper tdw = new ToyDecoratorWrapper(ty1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Before decoration:");
            Console.ResetColor();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Testing decoration::");
            Console.ResetColor();
            //I try to give the same thing twice to show that only one is accepted.
            tdw.GiveSword();
            tdw.GiveSword();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            tdw.GiveHelmet();
            tdw.GiveHelmet();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            tdw.GiveFlowerDress();
            tdw.GiveFlowerDress();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            tdw.GiveDottedDress();
            tdw.GiveDottedDress();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            tdw.GiveJump();
            tdw.GiveJump();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            tdw.GiveJokeStorytelling();
            tdw.GiveJokeStorytelling();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            tdw.GiveScaryStorytelling();
            tdw.GiveScaryStorytelling();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            tdw.GiveSoloCapoeira();
            tdw.GiveSoloCapoeira();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            tdw.GiveBreakdance();
            tdw.GiveBreakdance();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            tdw.GiveGangnamStyle();
            tdw.GiveGangnamStyle();
            Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("After Decoration + Testing Jump:");
            Console.ResetColor();
            for(int i=0; i<6;i++)
            {
                Console.WriteLine(tdw.Cost().ToString() + "||||" + tdw.height().ToString() + "||||" + tdw.Summary());
            }



            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------------MORE TESTS (without using Wrapper for simplification, hence allowing multiple decorators of same type if not carefully used)---------------------");
            Console.WriteLine("COST" + "||||" + "HEIGHT" + "||||" + "SUMMARY");
            Console.ResetColor();
            IToy doll = new Doll();
            Console.WriteLine(doll.ToString());
            IToy warrior = new Warrior();
            IToy raceDriver = new RaceDriver();
            // Please make sure to put here the code which shows what you've implemented
            BaseDecorator dec = new BaseDecorator(warrior);
            Console.WriteLine(dec.Cost().ToString() + "||||" + dec.height().ToString() + "||||" + dec.Summary());
            dec = new SwordDecorator(dec);
            Console.WriteLine(dec.Cost().ToString() + "||||" + dec.height().ToString() + "||||" + dec.Summary());
            dec = new HelmetDecorator(dec);
            Console.WriteLine(dec.Cost().ToString() + "||||" + dec.height().ToString() + "||||" + dec.Summary());
            IDress drs = new DottedDress();
            dec = new DressDecorator(dec, drs);
            Console.WriteLine(dec.Cost().ToString() + "||||" + dec.height().ToString() + "||||" + dec.Summary());
            drs = new FlowerDress();
            dec = new DressDecorator(dec, drs);
            Console.WriteLine(dec.Cost().ToString() + "||||" + dec.height().ToString() + "||||" + dec.Summary());
            //still happens when maximizing console window, so it's useless (->). //Console.Write(""); //might act almost like fflush() in c, because the above WriteLine wouldn't add a line console was in fullscreen somehow.
            IDance dnc = new gangnamStyle();
            dec = new DanceDecorator(dec, dnc);
            dnc = new soloCapoeira();
            dec = new DanceDecorator(dec, dnc);
            dnc = new breakdance();
            dec = new DanceDecorator(dec, dnc);
            Console.WriteLine(dec.Cost().ToString() + "||||" + dec.height().ToString() + "||||" + dec.Summary());
            Console.WriteLine("----Jump Testing Begins----");
            IToy toyJumper = new Doll();
            JumpDecorator jmpDec = new JumpDecorator(toyJumper);
            for(int i=0; i<6;i++)
            {
                Console.WriteLine(jmpDec.Cost().ToString() + "||||" + jmpDec.height().ToString() + "||||" + jmpDec.Summary());
            }
            Console.WriteLine("----Jump  Testing  Ends----");
            dec = new scaryStorytellingDecorator(dec);
            Console.WriteLine(dec.Cost().ToString() + "||||" + dec.height().ToString() + "||||" + dec.Summary());
            dec = new jokeStorytellingDecorator(dec);
            Console.WriteLine(dec.Cost().ToString() + "||||" + dec.height().ToString() + "||||" + dec.Summary());
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("COST" + "||||" + "HEIGHT" + "||||" + "SUMMARY");
            Console.WriteLine(dec.GetType());
            Console.ResetColor();

            Console.WriteLine("----MINOTAUR AND CENTAUR TESTING BEGINS----");
            xTaur taur = new Minotaur();
            BaseDecorator taurDec=new scaryStorytellingDecorator(taur);
            taurDec = new DressDecorator(taurDec, drs);
            taurDec = new DanceDecorator(taurDec, dnc);
            Console.WriteLine(taurDec.Cost().ToString() + "||||" + taurDec.height().ToString() + "||||" + taurDec.Summary());
            taur = new Centaur();
            taurDec = new jokeStorytellingDecorator(taur);
            drs = new DottedDress();
            taurDec = new DressDecorator(taurDec, drs);
            dnc = new gangnamStyle();
            taurDec = new DanceDecorator(taurDec, dnc);
            Console.WriteLine(taurDec.Cost().ToString() + "||||" + taurDec.height().ToString() + "||||" + taurDec.Summary());
        }
    }
}
