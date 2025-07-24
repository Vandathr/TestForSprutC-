using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForSprut
{
    internal class NullCell : ICanvasCell
    {
        public double GetX() => 0;
        public double GetY() => 0;
        public int GetColor() => 0;
        public IFigure GetOwner() => null;
        public void Move(int X, int Y) { }

    }
}
