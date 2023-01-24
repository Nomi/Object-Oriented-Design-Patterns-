using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Doll : IToy
    {
        public float Cost()
        {
            return 100f;
        }

        public string Summary()
        {
            return "I'm a doll.";
        }
        public float height()
        {
            return 25f;
        }
    }
}
