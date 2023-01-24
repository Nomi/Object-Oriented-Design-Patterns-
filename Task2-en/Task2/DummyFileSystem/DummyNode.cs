using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    public abstract class DummyNode : IFileSystemNode
    {

        public string Name { get; }
        public DummyNode Parent { get; protected set; }
        public DummyNode FirstChild { get; protected set; }
        public DummyNode Next { get; protected set; }
        private readonly bool isDir;

        public DummyNode(string name, bool isDir)
        {
            Name = name;
            this.isDir = isDir;
            Next = null;
            Parent = null;
        }
        public DummyNode(string name, DummyNode parent, bool isDir) : this(name, isDir)
        {
            Parent = parent;
            if (parent.FirstChild == null)
            {
                parent.FirstChild = this;
                return;
            }

            var currentNext = parent.FirstChild;
            while (currentNext.Next != null)
                currentNext = currentNext.Next;
            currentNext.Next = this;
        }

        public virtual string GetPrintableName()
        {
            return Name;
        }

        public abstract string GetPrintableContent();

        public DummyNode GetParent()
        {
            return Parent;
        }

        public bool IsDir()
        {
            return isDir;
        }

        //My additions:
        public bool visited = false;
        public int depth;
        public string transformedName;
        public string transformedContent;
    }
}
