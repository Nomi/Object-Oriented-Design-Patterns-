using System;

namespace PictureProduction
{
    public interface IPicture
    {
        string LeftFrame { get; }
        string RightFrame { get; }
        string Color { get; }
        string Text { get; }

        void Print();
    }

    public class Picture : IPicture
    {
        public string LeftFrame { get; set; }

        public string RightFrame { get; set; }

        public string Color { get; set; }

        public string Text { get; set; }

        public Picture()
        {
            Color = null;
            Text = null;
        }
        public Picture(IPicture ipic)
        {
            Color = ipic.Color;
            Text = ipic.Text;
            LeftFrame = ipic.LeftFrame;
            RightFrame = ipic.RightFrame;
        }

        public void Print()
        {
            Console.WriteLine($"{LeftFrame}{Color}{RightFrame} {Text} {LeftFrame}{Color}{RightFrame}");
        }
    }
}
