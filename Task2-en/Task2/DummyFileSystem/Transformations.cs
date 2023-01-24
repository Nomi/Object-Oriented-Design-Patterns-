using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public interface BaseTransformation
    {
        public abstract void ApplyTransform();
    }

    public class Transformer : IFileSystemNode  //public class Transform : IFileSystemNode
    {
        protected DummyNode node = null;
        public Transformer(DummyNode nd)
        {
            node = nd;
        }
        public DummyNode GetParent()
        {
            return node.GetParent();        //since node is on the left, the system knows that it's a DummyNode and calls its' method instead of trying to call the interface's or this function again
        }

        public virtual string GetPrintableContent()
        {
            return node.GetPrintableContent();
        }


        public virtual string GetPrintableName()
        {
            node.transformedName = "|";
            for (int i = 0; i < node.depth; i++)
            {
                node.transformedName += "-";
            }
            node.transformedName += node.Name;
            return node.transformedName;
        }

        public bool IsDir()
        {
            return node.IsDir();
        }
    }

    //public class Transformer: Transform
    //{
    //    public Transformer(DummyNode nd) : base(nd) { }
    //    public override GetPrintableName()
    //    {
    //        string transformedName;
    //        transformedName = "|";
    //        for (int i = 0; i < base.depth; i++)
    //        {
    //            transformedName += "-";
    //        }
    //        node.transformedName += node.Name;
    //    }
    //}


    public class TransformPrefix : Transformer
    {
        public TransformPrefix(DummyNode nd) : base(nd) { }
        public override string GetPrintableName()  //can't override somehow, maybe it's not needed since the BaseTransform is an interface.
        {
            node.transformedName = "|";
            for (int i = 0; i < node.depth; i++)
            {
                node.transformedName += "-";
            }
            node.transformedName += node.Name;
            return node.transformedName;
        }
    }

    public class TransformFileContent : Transformer
    {
        public TransformFileContent(DummyNode nd) : base(nd) { }
        public override string GetPrintableContent()
        {
            if (node.transformedContent == null)
            {
                node.transformedContent = node.GetPrintableContent();
            }
            if (!node.IsDir())
            {
                node.transformedContent = node.transformedContent.Replace("-", string.Empty);
            }
            if (!node.IsDir() && !node.Name.EndsWith(".cipher"))
            {
                if (node.transformedContent.Length == 0)
                {
                    if (node.GetPrintableContent().Length != 0)
                    {
                        //node.transformedContent = (node.GetPrintableContent() + "\n");
                        node.transformedContent += "\n";
                    }
                    else
                    {
                        node.transformedContent = "\n";
                        //the scenario when file doesn't have any content.
                    }
                }
                else
                {
                    node.transformedContent += "\n";
                }
            }
            if (!node.IsDir() && node.Name.EndsWith(".cipher"))
            {
                char[] charArray = node.transformedContent.ToCharArray();
                Array.Reverse(charArray);
                node.transformedContent = string.Empty;
                foreach (char ch in charArray)
                {
                    //node.transformedContent += (char)ch;
                    node.transformedContent += (char)((int)ch - 25);
                }
            }
            return node.transformedContent;
        }
    }
}





















//***newer Old code:***
/*
public class TransformPrefix : BaseTransformation
{
    protected DummyNode node;
    public TransformPrefix(DummyNode nd)
    {
        node = nd;
    }
    public void ApplyTransform()  //can't override somehow, maybe it's not needed since the BaseTransform is an interface.
    {
        node.transformedName = "|";
        for (int i = 0; i < node.depth; i++)
        {
            node.transformedName += "-";
        }
        node.transformedName += node.Name;
    }
}

public class TransformAllFileContent : BaseTransformation
{
    protected DummyNode node;
    public TransformAllFileContent(DummyNode nd)
    {
        node = nd;
    }
    public void ApplyTransform()
    {
        if (node.transformedContent == null)
        {
            node.transformedContent = node.GetPrintableContent();
        }
        if (!node.IsDir())
        {
            node.transformedContent = node.transformedContent.Replace("-", string.Empty);
        }
    }
}

public class TransformNonCipherFileContents : BaseTransformation
{
    protected DummyNode node;
    public TransformNonCipherFileContents(DummyNode nd)
    {
        node = nd;
    }
    public void ApplyTransform()
    {
        if (node.transformedContent == null)
        {
            node.transformedContent = node.GetPrintableContent();
        }
        if (!node.IsDir() && !node.Name.EndsWith(".cipher"))
        {
            if (node.transformedContent.Length == 0)
            {
                if (node.GetPrintableContent().Length != 0)
                {
                    //node.transformedContent = (node.GetPrintableContent() + "\n");
                    node.transformedContent += "\n";
                }
                else
                {
                    node.transformedContent = "\n";
                    //the scenario when file doesn't have any content.
                }
            }
            else
            {
                node.transformedContent += "\n";
            }
        }
    }
}


public class TransformCipherFileContents : BaseTransformation
{
    protected DummyNode node;
    public TransformCipherFileContents(DummyNode nd)
    {
        node = nd;
    }
    public void ApplyTransform()
    {
        if (node.transformedContent == null)
        {
            node.transformedContent = node.GetPrintableContent();
        }
        if (!node.IsDir() && node.Name.EndsWith(".cipher"))
        {
            char[] charArray = node.transformedContent.ToCharArray();
            Array.Reverse(charArray);
            node.transformedContent = string.Empty;
            foreach (char ch in charArray)
            {
                //node.transformedContent += (char)ch;
                node.transformedContent += (char)((int)ch - 25);
            }
        }
    }
}
}*/


//****old code:****
/*
using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public interface BaseTransformation
    {
        public abstract void ApplyTransform(DummyNode node);
    }
    public class TransformPrefix : BaseTransformation
    {
        public TransformPrefix(BaseTransformation inputBase)
        {
            baseTr = inputBase;
        }
        public override void ApplyTransform(DummyNode node)
        {
            node.transformedName = "|";
            for (int i = 0; i < node.depth; i++)
            {
                node.transformedName += "-";
            }
            node.transformedName += node.Name;
        }
    }

    public class TransformAllFileContent : BaseTransformation
    {
        public void ApplyTransform(DummyNode node)
        {
            if (!node.IsDir())
            {
                node.transformedContent = node.transformedContent.Replace("-", string.Empty);
            }
        }
    }

    public class TransformNonCipherFileContents : BaseTransformation
    {
        public void ApplyTransform(DummyNode node)
        {
            if (!node.IsDir() && !node.Name.EndsWith(".cipher"))
            {
                if (node.transformedContent.Length == 0)
                {
                    if (node.GetPrintableContent().Length != 0)
                    {
                        //node.transformedContent = (node.GetPrintableContent() + "\n");
                        node.transformedContent += "\n";
                    }
                    else
                    {
                        node.transformedContent = "\n";
                        //the scenario when file doesn't have any content.
                    }
                }
                else
                {
                    node.transformedContent += "\n";
                }
            }
        }
    }


    public class TransformCipherFileContents : BaseTransformation
    {
        public void ApplyTransform(DummyNode node)
        {
            if (!node.IsDir() && node.Name.EndsWith(".cipher"))
            {
                char[] charArray = node.transformedContent.ToCharArray();
                Array.Reverse(charArray);
                node.transformedContent = string.Empty;
                foreach (char ch in charArray)
                {
                    //node.transformedContent += (char)ch;
                    node.transformedContent += (char)((int)ch - 25);
                }
            }
        }
    }
}

*/
