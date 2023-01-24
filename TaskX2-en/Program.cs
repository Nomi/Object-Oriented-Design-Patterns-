using System;
using System.Collections.Generic;

namespace PictureProduction
{
    class Program
    {
        public static AbstractProductionLine productionLine;
        private readonly static Order[] orders =
        {
            new Order("circle", "red", "Hello", "spacing"),
            new Order("square", "green", "HelloWorld", "spacing"),
            new Order("triangle", "blue", "ChainIsBeauty", "spacing"),

            new Order("circle", "red", "Hello", "uppercase"),
            new Order("square", "green", "HelloWorld", "uppercase"),
            new Order("triangle", "blue", "ChainIsBeauty", "uppercase"),

            new Order("circle", "red", "Hello", "lowercase"),
            new Order("square", "yellow", "HelloWorld", "lowercase"),
            new Order("hash", "red", "ChainIsBeauty", "uppercase"),  //REMARK: THIS IS A WRONG SHAPE so "ERROR: CANNOT CREATE PICTURE" is printed according to the task.

            new Order("", "green", "ChainIsBeauty", "uppercase"), //invalid order
            new Order("star", "1234", "ChainIsBeauty", "uppercase"), //invalid order
            new Order("star", "green", null, "uppercase"), //invalid order
        };

        static void ProducePictures(IEnumerable<Order> orders)
        {
            foreach(Order o in orders)
            {
                IPicture pic=new Picture();
                productionLine.Handle(o, pic);
            }
        }

        static void Main(string[] args)
        {
            //the instance productionLine is a static member of the Program class, that's why everything in Main and ProducePictures can access it.
            productionLine= ProductionLineMaker.MakeSimpleProductionLine();
            ///Can also do something like:
            ///productionLine.AddAcceptableColor("red");,
            ///productionLine.AddAcceptableShape(new circleShape());,
            ///productionLine.AddAcceptableOperation(new spacingOperation());,
            ///,etc

            
            Console.WriteLine("--- Simple Production Line ---");
            ProducePictures(orders);

            Console.WriteLine();

            Console.WriteLine("--- Complex Production Line ---");
            productionLine = ProductionLineMaker.MakeComplexProductionLine();
            ProducePictures(orders);

            Console.WriteLine(Environment.NewLine+Environment.NewLine);
            Console.WriteLine("EXTRA: __Testing case (for complex prod line) when spacing is used and no valid color: (should get 3 thickness according to task)__");
            productionLine.Handle(new Order("triangle", "purple", "WowoW", "spacing"), new Picture());
            Console.WriteLine(Environment.NewLine + Environment.NewLine);
        }
    }
}
