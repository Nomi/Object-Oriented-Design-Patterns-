using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Warrior : IToy
    {
        public float Cost()
        {
            return 150f;
        }

        public string Summary()
        {
            return "I'm a warrior!";
        }
        public float height()
        {
            return 30f;
        }
    }
}
