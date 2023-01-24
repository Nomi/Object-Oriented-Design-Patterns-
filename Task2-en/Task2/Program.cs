using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
    static void Main(string[] args)
        {
            var root = new DummyDirectory("root");

            var csProjects = new DummyDirectory("CSharpProjects", root);
            var csProject1 = new DummyDirectory("CSharpHelloWorld", csProjects);
            new DummyFile("HelloWorld.cs", "--C-o-n-sol--e-.-W---r-i-teLine-(---\"Hello, World!\");", csProject1);
            var csProject2 = new DummyDirectory("CSharpDE", csProjects);
            new DummyFile("HelloWorld.cs", "Console.WriteL----ine(\"Hallo, Welt!\");", csProject2);

            var pythonProjects = new DummyDirectory("python-projects", root);
            var pythonProject1 = new DummyDirectory("python-hw", pythonProjects);
            var pythonProject1Package = new DummyDirectory("hello_world", pythonProject1);
            new DummyFile("requirements.txt", "pyt---est", pythonProject1);
            new DummyFile("main.py", "prin---t('Hello W--orld!')", pythonProject1Package);

            var rustProjects = new DummyDirectory("rust", root);
            var rustProject1 = new DummyDirectory("hello-rust", rustProjects);
            var rustSrc = new DummyDirectory("src", rustProject1);
            new DummyFile("Cargo.toml", "[pac---kage]\nnam---e = \"hello-rust\"", rustProject1);
            new DummyFile("main.rs", "fn main() { pri--nt-l--n--!(\"Hello, student!\"); }", rustSrc);

            var dir1 = new DummyDirectory("very-important-documents", root);
            var dir2 = new DummyDirectory("homework", dir1);
            var dir3 = new DummyDirectory("DONTENTERHERE", dir2);
            var dir4 = new DummyDirectory("dangerous-zone", dir3);
            new DummyFile("cats.txt.cipher", "#9U9w9W---9-#-B-9G9---A-#-u-H-xuH9", dir4);

            Console.WriteLine("--------BFS--------");
            // 1. Iterate over the dummy filesystem (strating from root) in BFS order
            // For each node please print its name and contents if it's available
            // 
            // var printableContent = node.GetPrintableContent();
            // if (printableContent != null)
            // {
            //     Console.WriteLine(printableContent);
            // }
            //            BFSIterator itr = new BFSIterator(root);
            //var en = itr.GetEnumerator();
            //var sth = new DummyNode[4];
            //for (var i = 0; i< 4; i++)
            //{
            //    sth[i] = en.Current;
            //    en.MoveNext();
            //}

            //Console.WriteLine("Now im doing something else");

            //while (en.MoveNext())
            //{
            //    var e = en.Current;
            //}
            //foreach (var dnItr in new BFSIterator(csProjects))
            //{
            //    ConsoleColor temp = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.White;
            //    if (dnItr.IsDir())
            //    {
            //        Console.WriteLine(dnItr.GetPrintableName()); Console.WriteLine(); 
            //    }
            //    else
            //    {
            //        Console.Write(dnItr.Name + "          Content:");
            //        Console.ForegroundColor = temp;
            //        Console.WriteLine(dnItr.GetPrintableContent()); 
            //        Console.WriteLine(); 
            //    }
            //    Console.ForegroundColor = temp;
            //    i++;
            //        if(i==5)
            //    {
            //        break;
            //    }
            //}
            Iterator iterator = new BFSIterator(root);
            while(iterator.CurrentItem()!=null)
            {
                var dnItr = iterator.CurrentItem();
                ConsoleColor temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                if (dnItr.IsDir())
                {
                    Console.WriteLine(dnItr.GetPrintableName()); Console.WriteLine();
                }
                else
                {
                    Console.Write(dnItr.Name + "\n" + "          Content:\n");
                    Console.ForegroundColor = temp;
                    Console.WriteLine(dnItr.GetPrintableContent());
                    Console.WriteLine();
                }
                Console.ForegroundColor = temp;
                iterator.Next();
            }
            //foreach (var dnItr in iterator)
            //{
            //    ConsoleColor temp = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.White;
            //    if (dnItr.IsDir())
            //    {
            //        Console.WriteLine(dnItr.GetPrintableName()); Console.WriteLine();
            //    }
            //    else
            //    {
            //        Console.Write(dnItr.Name +"\n"+"          Content:\n");
            //        Console.ForegroundColor = temp;
            //        Console.WriteLine(dnItr.GetPrintableContent());
            //        Console.WriteLine();
            //    }
            //    Console.ForegroundColor = temp;
            //}
            Console.WriteLine("-----------------");
            Console.WriteLine("--------DFS--------");
            // 2. Iterate over the dummy filesystem (strating from root) in DFS order
            // For each node please print its name and contents if it's available
            // 
            // var printableContent = node.GetPrintableContent();
            // if (printableContent != null)
            // {
            //     Console.WriteLine(printableContent);
            // }
            // Make sure that:
            // 1. Before each name print '|' and N times '-', where N is the depth of the file in the filesystem
            // (number of parents until null is reached)
            // 2. If node is not a directory, apply a transformation to its content which removes all hyphens ('-').
            // 3. If node is not a directory and its name doesn't end with ".cipher", append newline character to
            // its content ('\n').
            // 4. If node's name ends with ".cipher", in addition to all previous transformations, apply two more:
            //      - Reverse its content (character-wise, e.g. "asd" becomes "dsa")
            //      - Subtract 25 from each character in its content (cast char to int), e.g. 'z' - 25 = 'a'

            iterator = new DFSIterator(root);
            while (iterator.CurrentItem() != null)
            {
                var dnItr = iterator.CurrentItem();
                Transformer T = new TransformPrefix(dnItr);
                ConsoleColor temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;//ConsoleColor.White;
                if (T.IsDir())
                {
                    Console.WriteLine(T.GetPrintableName()); Console.WriteLine();
                }
                else
                {
                    Console.Write(T.GetPrintableName() + "\n" + "          Content:\n");
                    Console.ForegroundColor = temp;
                    T = new TransformFileContent(dnItr);
                    Console.WriteLine(T.GetPrintableContent());
                    Console.WriteLine();
                }
                Console.ForegroundColor = temp;
                iterator.Next();
            }
            Console.WriteLine("-------------------");
        }

        ////iterator = new DFSIterator(root);
        //////foreach (var dnItr in iterator)
        //////{
        //////    //old code:
        //////    //dnItr.transformedContent = dnItr.GetPrintableContent();
        //////    //BaseTransformation transform = new TransformPrefix();
        //////    //transform.ApplyTransform(dnItr);
        //////    //transform = new TransformAllFileContent();
        //////    //transform.ApplyTransform(dnItr);
        //////    //transform = new TransformNonCipherFileContents();
        //////    //transform.ApplyTransform(dnItr);
        //////    //transform = new TransformCipherFileContents();
        //////    //transform.ApplyTransform(dnItr);
        //////    //old code ends.
        //////    //newer old code begins:
        //////    //BaseTransformation transform = new TransformPrefix(dnItr);
        //////    //transform.ApplyTransform();
        //////    //if (dnItr.GetPrintableContent() != null)
        //////    //{
        //////    //    transform = new TransformAllFileContent(dnItr);
        //////    //    transform.ApplyTransform();
        //////    //    transform = new TransformNonCipherFileContents(dnItr);
        //////    //    transform.ApplyTransform();
        //////    //    transform = new TransformCipherFileContents(dnItr);
        //////    //    transform.ApplyTransform();
        //////    //}
        //////    //newer old code ends.
        //////    Transformer T = new TransformPrefix(dnItr);
        //////    ConsoleColor temp = Console.ForegroundColor;
        //////    Console.ForegroundColor = ConsoleColor.Red;//ConsoleColor.White;
        //////    if (T.IsDir())
        //////    {
        //////        Console.WriteLine(T.GetPrintableName()); Console.WriteLine();
        //////    }
        //////    else
        //////    {
        //////        Console.Write(T.GetPrintableName() +"\n"+"          Content:\n");
        //////        Console.ForegroundColor = temp;
        //////        T = new TransformFileContent(dnItr);
        //////        Console.WriteLine(T.GetPrintableContent());
        //////        Console.WriteLine();
        //////    }
        //////    Console.ForegroundColor = temp;
        //////}
        //////Console.WriteLine("-------------------");
    }
    
}
