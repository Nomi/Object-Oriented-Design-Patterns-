using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class RaceDriver : IToy
    {
        public float Cost()
        {
            return 200f;
        }

        public string Summary()
        {
            return "I'm a race driver.";
        }
        
        public float height()
        {
            return 20f;
        }
    }
}
