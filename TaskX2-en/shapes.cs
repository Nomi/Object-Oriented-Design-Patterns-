using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureProduction
{
    public interface IShape
    {
        public string name { get;}
        public char subShapeL { get; }
        public char subShapeR { get;}
        public string leftFrame(int width)
        {
            string str = "";
            for(int i =0; i<width;i++)
            {
                str += subShapeL;
            }
            return str;
        }
        public string rightFrame(int width)
        {
            string str = "";
            for (int i = 0; i < width; i++)
            {
                str += subShapeR;
            }
            return str;
        }
    }

    public class triangleShape : IShape
    {
        public string name => "triangle";

        public char subShapeL => '<';

        public char subShapeR => '>';
    }
    public class squareShape : IShape
    {
        public string name => "square";

        public char subShapeL => '[';

        public char subShapeR => ']';
    }
    public class circleShape : IShape
    {
        public string name => "circle";

        public char subShapeL => '(';

        public char subShapeR => ')';
    }
}
