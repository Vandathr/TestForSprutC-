using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForSprut
{
    internal interface ICanvasCell
    {
        double GetX();
        double GetY();
        int GetColor();
        IFigure GetOwner();
        void Move(int X, int Y);
    }
}
