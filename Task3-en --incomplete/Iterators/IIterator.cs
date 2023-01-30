using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public interface IIterator
    {
        //each class implmenting the interface IIterator needs to at least have an element VirusData current;
        VirusData getCurrent();
        VirusData next();
        bool isAftertLastElement();
    }
}
