using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureProduction
{
    public enum ProductionLineTypes { Simple, Complex };
    public class AbstractProductionLine : IMachine
    {
        private IMachine _nextHandler;
        StringBuilder stringBuilder = new StringBuilder();
        //public ProductionLineTypes type;

        //public AbstractProductionLine(ProductionLineTypes typ)
        //{
        //    type = typ;
        //}
        public AbstractProductionLine()
        {
            _nextHandler = null;
        }
        public AbstractProductionLine(IMachine nhandler)
        {
            _nextHandler = nhandler;
        }

        public virtual void AddAcceptableColor(string col)
        {
            this._nextHandler.AddAcceptableColor(col);
        }

        public virtual void AddAcceptableOperation(ITextOperation op)
        {
            this._nextHandler.AddAcceptableOperation(op);
        }

        public virtual void AddAcceptableShape(IShape shape)
        {
            this._nextHandler.AddAcceptableShape(shape);
        }

        public virtual void Handle(Order order, IPicture picture)
        {
            if (this._nextHandler != null)
            {
                Picture picture1 = new Picture(picture);
                this.Handle(order,picture1);
            }
        }
        public virtual void Handle(Order order, Picture picture)
        {
            if (this._nextHandler != null)
            {
                this._nextHandler.Handle(order, picture);
            }
        }

        public IMachine SetNext(IMachine handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        //public bool validator(Order o)
        //{
        //    bool isInvalid = false;
        //    if(o.Shape.Length<1)
        //    {
        //        isInvalid = true;
        //    }
        //    else
        //    {
        //        foreach (char c in o.Shape.ToArray())
        //        {
        //            if (!char.IsLetter(c))
        //            {
        //                isInvalid = true;
        //                break;
        //            }
        //        }
        //    }
        //    if(!isInvalid)
        //    {
        //        if (o.Color.Length < 1)
        //        {
        //            isInvalid = true;
        //        }
        //        else
        //        {
        //            foreach (char c in o.Color.ToArray())
        //            {
        //                if (!char.IsLetter(c))
        //                {
        //                    isInvalid = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    if (!isInvalid)
        //    {
        //        if (o.Text==null)
        //        {
        //            isInvalid = true;
        //        }
        //        else
        //        {
        //            if (o.Text.Length < 1)
        //            {
        //                isInvalid = true;
        //            }
        //            else
        //            {
        //                foreach (char c in o.Text.ToArray())
        //                {
        //                    if (!char.IsLetter(c))
        //                    {
        //                        isInvalid = true;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    if (!isInvalid)
        //    {
        //        if (o.Text.Length < 1)
        //        {
        //            isInvalid = true;
        //        }
        //        else
        //        {
        //            foreach (char c in o.Text.ToArray())
        //            {
        //                if (!char.IsLetter(c))
        //                {
        //                    isInvalid = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return (!isInvalid);
        //}
    }

    class ValidationHandler : AbstractProductionLine
    {
        public ValidationHandler() { }
        public ValidationHandler(IMachine nhandler) : base(nhandler) { }
        public override void Handle(Order order, Picture picture)
        {
            Order o = order;
            bool isInvalid = false;
            if (o.Shape.Length < 1)
            {
                isInvalid = true;
            }
            else
            {
                foreach (char c in o.Shape.ToArray())
                {
                    if (!char.IsLetter(c))
                    {
                        isInvalid = true;
                        break;
                    }
                }
            }
            if (!isInvalid)
            {
                if (o.Color.Length < 1)
                {
                    isInvalid = true;
                }
                else
                {
                    foreach (char c in o.Color.ToArray())
                    {
                        if (!char.IsLetter(c))
                        {
                            isInvalid = true;
                            break;
                        }
                    }
                }
            }
            if (!isInvalid)
            {
                if (o.Text == null)
                {
                    isInvalid = true;
                }
                else
                {
                    if (o.Text.Length < 1)
                    {
                        isInvalid = true;
                    }
                    else
                    {
                        foreach (char c in o.Text.ToArray())
                        {
                            if (!char.IsLetter(c))
                            {
                                isInvalid = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (!isInvalid)
            {
                if (o.Operation.Length < 1)
                {
                    isInvalid = true;
                }
                else
                {
                    foreach (char c in o.Operation.ToArray())
                    {
                        if (!char.IsLetter(c))
                        {
                            isInvalid = true;
                            break;
                        }
                    }
                }
            }
            if (isInvalid)
            {
                Console.WriteLine("Error: Invalid order!");
                return;
            }
            else
            {
                base.Handle(order, picture);
            }
        }
    }
    class SimpleColorMachine : AbstractProductionLine
    {
        public SimpleColorMachine() { }
        public SimpleColorMachine(IMachine nhandler) : base(nhandler) { }
        public override void Handle(Order order, Picture picture)
        {
            //if (!validator(order))
            //{
            //    Console.WriteLine("Error: Invalid order!");
            //    return;
            //}
            if (order.Color == "red")
                picture.Color = order.Color;
            else
                picture.Color = "";

            base.Handle(order, picture);
        }

        //public bool validator(Order o)
        //{
        //    bool isInvalid = false;
        //    if (o.Shape.Length < 1)
        //    {
        //        isInvalid = true;
        //    }
        //    else
        //    {
        //        foreach (char c in o.Shape.ToArray())
        //        {
        //            if (!char.IsLetter(c))
        //            {
        //                isInvalid = true;
        //                break;
        //            }
        //        }
        //    }
        //    if (!isInvalid)
        //    {
        //        if (o.Color.Length < 1)
        //        {
        //            isInvalid = true;
        //        }
        //        else
        //        {
        //            foreach (char c in o.Color.ToArray())
        //            {
        //                if (!char.IsLetter(c))
        //                {
        //                    isInvalid = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    if (!isInvalid)
        //    {
        //        if (o.Text == null)
        //        {
        //            isInvalid = true;
        //        }
        //        else
        //        {
        //            if (o.Text.Length < 1)
        //            {
        //                isInvalid = true;
        //            }
        //            else
        //            {
        //                foreach (char c in o.Text.ToArray())
        //                {
        //                    if (!char.IsLetter(c))
        //                    {
        //                        isInvalid = true;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    //if (!isInvalid)
        //    //{
        //    //    if (o.Operation.Length < 1)
        //    //    {
        //    //        isInvalid = true;
        //    //    }
        //    //    else
        //    //    {
        //    //        foreach (char c in o.Operation.ToArray())
        //    //        {
        //    //            if (!char.IsLetter(c))
        //    //            {
        //    //                isInvalid = true;
        //    //                break;
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //    return (!isInvalid);
        //}

    }



    class CustomizableColorMachine : AbstractProductionLine
    {
        List<string> acceptedColors = new List<string>();
        public CustomizableColorMachine(IMachine nhandler, List<string> colorsToAccept) : base(nhandler)
        {
            if (colorsToAccept != null)
                acceptedColors = colorsToAccept;
        }
        public override void Handle(Order order, Picture picture)
        {
            bool colorSet = false;
            foreach (string col in acceptedColors)
            {
                if (col == order.Color)
                {
                    picture.Color = col;
                    colorSet = true;
                }
            }
            if (!colorSet)
            {
                picture.Color = String.Empty;
            }

            base.Handle(order, picture);
        }
        public override void AddAcceptableColor(string col)
        {
            acceptedColors.Add(col);
        }
    }
    class CustomizableTextMachine : AbstractProductionLine
    {
        List<ITextOperation> acceptableOperations = new List<ITextOperation>();
        public CustomizableTextMachine(IMachine nhandler, List<ITextOperation> operationsToAccept) : base(nhandler)
        {
            if (operationsToAccept != null)
                acceptableOperations = operationsToAccept;
        }
        public override void Handle(Order order, Picture picture)
        {
            bool operationPerformed = false;
            foreach (var aOP in acceptableOperations)
            {
                if (aOP.name == order.Operation)
                {
                    if (order.Text != null)
                        picture.Text = aOP.Perform(order.Text);
                    else
                        picture.Text = order.Text;
                    operationPerformed = true;
                }
            }
            if (!operationPerformed)
            {
                picture.Text = order.Text;
            }
            base.Handle(order, picture);
        }
        public override void AddAcceptableOperation(ITextOperation op)
        {
            acceptableOperations.Add(op);
        }
    }
    public class CustomizableFrameMachine : AbstractProductionLine
    {
        List<IShape> acceptableShapes = new List<IShape>();
        string TYPE;
        public CustomizableFrameMachine(IMachine nhandler, List<IShape> shapesToAccept, string type) : base(nhandler)
        {
            TYPE = type;
            if (shapesToAccept != null)
                acceptableShapes = shapesToAccept;
        }
        public override void Handle(Order order, Picture picture)
        {
            if (picture.Color == null || picture.Text == null)
            {
                Console.WriteLine("Error: Cannot frame picture because Color or Text is null!");
                return;
            }
            int width = 1;
            bool finalWidthSet = false;
            if (picture.Color.Length < 1) //color is empty
            {
                width = 2;
                finalWidthSet = true;
            }
            //no else condition here because both can occur together
            if (picture.Text.Length > order.Text.Length)
            {
                if (picture.Color.Length < 1)  //color is empty string && spacing used
                {
                    width = 3;
                    finalWidthSet = true; //not needed here, already done above. But just to be safe :P!
                }
                else     //spacing used, but color is not empty
                {
                    width = 2;
                    finalWidthSet = true;
                }
            }
            else if (!finalWidthSet)// none of the above were true.
            {
                width = 1;
            }
            if (TYPE == "simple")
            {
                width = 2;
            }
            bool shapeSet = false;
            foreach (IShape shape in acceptableShapes)
            {
                if (shape.name == order.Shape)
                {
                    picture.LeftFrame = shape.leftFrame(width);
                    picture.RightFrame = shape.rightFrame(width);
                    shapeSet = true;
                    break;
                }
            }
            if (!shapeSet)
            {
                Console.WriteLine("Error: Cannot create picture!");
                return;
            }
            base.Handle(order, picture);
        }
        public override void AddAcceptableShape(IShape shp)
        {
            acceptableShapes.Add(shp);
        }
    }







    /// <summary>
    /// THE FOLLOWING CLASSES ARE DEPRECATED!!!
    /// </summary>
    class SimpleTextMachine : AbstractProductionLine
    {
        public SimpleTextMachine() { }
        public SimpleTextMachine(IMachine nhandler) : base(nhandler) { }
        public override void Handle(Order order, Picture picture)
        {
            picture.Text = order.Text;
            base.Handle(order, picture);
        }
    }
    class SimpleFrameMachine : AbstractProductionLine
    {
        //List<string> acceptableShapes = new List<string>();
        List<IShape> acceptableShapes = new List<IShape>();
        public SimpleFrameMachine()
        {
            //acceptableShapes.Add("circle");
            //acceptableShapes.Add("square");
            acceptableShapes.Add(new circleShape());
            acceptableShapes.Add(new squareShape());
        }
        public SimpleFrameMachine(IMachine nhandler) : base(nhandler)
        {
            //acceptableShapes.Add("circle");
            //acceptableShapes.Add("square");
            acceptableShapes.Add(new circleShape());
            acceptableShapes.Add(new squareShape());
        }
        public SimpleFrameMachine(IMachine nhandler, List<IShape> shapesToAccept) : base(nhandler)
        {
            if(shapesToAccept!=null)
                shapesToAccept = acceptableShapes;
        }
        public override void Handle(Order order, Picture picture)
        {
            if (picture.Color == null || picture.Text == null)
            {
                Console.WriteLine("Error: Cannot frame picture because Color or Text is null!");
                return;
            }
            bool shapeSet = false;
            int defaultWidth = 2;
            foreach (IShape shape in acceptableShapes)
            {
                if (shape.name == order.Shape)
                {
                    picture.LeftFrame = shape.leftFrame(defaultWidth);
                    picture.RightFrame = shape.rightFrame(defaultWidth);
                    shapeSet = true;
                }
            }
            if (!shapeSet)
            {
                Console.WriteLine("Error: Cannot create picture!");
                return;
            }
            //string leftFrame= "";
            //string rightFrame="";
            //if(order.Shape=="circle")
            //{
            //    for (int i = 0; i < 2; i++)
            //    {
            //        leftFrame += '(';
            //        rightFrame += ')';
            //    }
            //}
            //else if(order.Shape=="square")
            //{
            //    for (int i = 0; i < 2; i++)
            //    {
            //        leftFrame += '[';
            //        rightFrame += ']';
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Error: Cannot create picture!");
            //    return;
            //}
            //picture.LeftFrame = leftFrame;
            //picture.RightFrame = rightFrame;
            base.Handle(order, picture);
        }
    }
    class PrintingPressMachine : AbstractProductionLine
    {
        public override void Handle(Order order, Picture picture)
        {
            picture.Print();
            base.Handle(order, picture);
        }
    }





    public class ComplexColorMachine : AbstractProductionLine
    {
        public ComplexColorMachine() { }
        public ComplexColorMachine(IMachine nhandler) : base(nhandler) { }
        public override void Handle(Order order, Picture picture)
        {
            //if (!validator(order))
            //{
            //    Console.WriteLine("Error: Invalid order!");
            //    return;
            //}
            if (order.Color == "red")
                picture.Color = order.Color;
            else if (order.Color == "green")
                picture.Color = order.Color;
            else if (order.Color == "blue")
                picture.Color = order.Color;
            else
                picture.Color = "";
            base.Handle(order, picture);
        }
    }
    class ComplexTextMachine : AbstractProductionLine
    {
        public ComplexTextMachine() { }
        public ComplexTextMachine(IMachine nhandler) : base(nhandler) { }
        public override void Handle(Order order, Picture picture)
        {
            if (order.Operation == "uppercase")
            {
                picture.Text = order.Text.ToUpper();
            }
            else if (order.Operation == "spacing")
            {
                picture.Text = order.Text.Aggregate(string.Empty, (c, i) => c + i + ' ');
            }
            else
            {
                picture.Text = order.Text;
            }
            base.Handle(order, picture);
        }
    }

    class ComplexFrameMachine : AbstractProductionLine
    {
        List<string> acceptableShapes = new List<string>();
        public ComplexFrameMachine()
        {
            acceptableShapes.Add("circle");
            acceptableShapes.Add("square");
            acceptableShapes.Add("triangle");
        }
        public ComplexFrameMachine(IMachine nhandler) : base(nhandler)
        {
            acceptableShapes.Add("circle");
            acceptableShapes.Add("square");
            acceptableShapes.Add("triangle");
        }
        public override void Handle(Order order, Picture picture)
        {
            if (picture.Color == null || picture.Text == null)
            {
                Console.WriteLine("Error: Cannot frame picture because Color or Text is null!");
                return;
            }
            //if(acceptableShapes.Contains(order.Shape))
            //{
            //    picture.LeftFrame
            //}
            string leftFrame = "";
            string rightFrame = "";
            int width = 1;
            if (picture.Color.Length < 1)
            {
                width = 2;
            }
            //no else here because both can occur together
            if (picture.Text.Length > order.Text.Length) //spacing used
            {
                if (picture.Color.Length < 1)  //color is empty string
                {
                    width = 3;
                }
                else
                {
                    width = 2;
                }
            }
            //else if(picture.Text==order.Text.ToUpper()) //uppercase was used
            //{
            //    width = 
            //}
            else // none of the above were true.
            {
                width = 1;
            }
            if (order.Shape == "circle")
            {
                for (int i = 0; i < width; i++)
                {
                    leftFrame += '(';
                    rightFrame += ')';
                }
            }
            else if (order.Shape == "square")
            {
                for (int i = 0; i < width; i++)
                {
                    leftFrame += '[';
                    rightFrame += ']';
                }
            }
            else if (order.Shape == "triangle")
            {
                for (int i = 0; i < width; i++)
                {
                    leftFrame += '<';
                    rightFrame += '>';
                }
            }
            else
            {
                Console.WriteLine("Error: Cannot create picture!");
                return;
            }
            picture.LeftFrame = leftFrame;
            picture.RightFrame = rightFrame;
            base.Handle(order, picture);
        }
    }




}