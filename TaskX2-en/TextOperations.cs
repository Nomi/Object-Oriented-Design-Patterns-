using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureProduction
{
    public interface ITextOperation
    {
        public string name { get; }
        public string Perform(string str);
    }

    public class uppercaseOperation :ITextOperation
    {
        public string name => "uppercase";
        public string Perform(string str)
        {
            return str.ToUpper();
        }
    }
    public class spacingOperation : ITextOperation
    {
        public string name => "spacing";
        public string Perform(string str)
        {
            return str.Aggregate(string.Empty, (c, i) => c + i + ' ');
        }
    }

}
