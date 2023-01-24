using System;
using System.Collections.Generic;

namespace Task2
{
    public interface IFileSystemNode
    {
        public string GetPrintableName();
        public string GetPrintableContent();
        public DummyNode GetParent();
        public bool IsDir();
    }
}
