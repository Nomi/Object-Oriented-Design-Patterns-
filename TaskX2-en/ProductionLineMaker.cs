using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureProduction
{
    static public class ProductionLineMaker
    {
        static public AbstractProductionLine MakeSimpleProductionLine()
        {
            ///AbstractProductionLine abl = new SimpleColorMachine();
            ///AbstractProductionLine abl2 = new SimpleTextMachine();
            ///AbstractProductionLine abl3 = new SimpleFrameMachine();
            ///abl3.SetNext(new PrintingPressMachine());
            ///abl2.SetNext(abl3);
            ///abl.SetNext(abl2);
            ///return abl;

            //return new ValidationHandler(new SimpleColorMachine(new SimpleTextMachine(new SimpleFrameMachine(new PrintingPressMachine()))));


            //ACTUAL USAGE:
            List<string> colorsToAccept = null; //Keeping this null to show how adding colors later doesn't need change in code of machines.
            List<ITextOperation> textOperationsToAccept = null; // this one actually needs to be null because of the task description of simpleProd Line
            List<IShape> shapesToAccept = new List<IShape>();
            shapesToAccept.Add(new circleShape()); //only adding circle at first.
            //will add square directly to production line to showcase how it works!
            AbstractProductionLine apl = new ValidationHandler(new CustomizableColorMachine(new CustomizableTextMachine(new CustomizableFrameMachine(new PrintingPressMachine(), shapesToAccept, "simple"), textOperationsToAccept), colorsToAccept));
            apl.AddAcceptableColor("red");
            apl.AddAcceptableShape(new squareShape());
            return apl;
        }
        static public AbstractProductionLine MakeComplexProductionLine()
        {
            //old:
            ///return new ValidationHandler(new ComplexColorMachine(new ComplexTextMachine(new ComplexFrameMachine(new PrintingPressMachine()))));
            //new:
            List<string> colorsToAccept = new List<string>(); colorsToAccept.Add("red"); colorsToAccept.Add("green"); //WILL ADD BLUE AFTER CREATION JUST TO SHOWCASE HOW THIS WORKS
            List<ITextOperation> textOperationsToAccept = new List<ITextOperation>(); textOperationsToAccept.Add(new uppercaseOperation()); //WILL ADD CASING LATER JUST TO SHOW HOW THIS CAN WORK
            List<IShape> shapesToAccept = new List<IShape>(); shapesToAccept.Add(new squareShape()); shapesToAccept.Add(new triangleShape()); shapesToAccept.Add(new circleShape()); //adding everything here just to show it works this way too. Already tested other way in simple Production line part.
            AbstractProductionLine apl = new ValidationHandler(new CustomizableColorMachine(new CustomizableTextMachine(new CustomizableFrameMachine(new PrintingPressMachine(),shapesToAccept,"complex"),textOperationsToAccept),colorsToAccept));
            apl.AddAcceptableColor("blue");
            apl.AddAcceptableOperation(new spacingOperation());
            return apl;
        }
    }
}
